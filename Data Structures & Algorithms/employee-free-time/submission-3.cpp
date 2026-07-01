class Solution {

    struct Employee {
        Employee(vector<Interval>&& schedule)
        {
            this->schedule = std::move(schedule);
        }

        vector<Interval> schedule;

        int last_start() const
        {
            return this->schedule.back().start;
        }

        int last_end() const {
            return this->schedule.back().end;
        }
    };

    struct CompareEmployeePointers {
    bool operator()(const Employee* a, const Employee* b) const {
        // To process intervals from right to left (largest start first),
        // we use a max-heap based on the start time of the last interval.
        return a->last_end() < b->last_end(); 
    }
};

public:
    vector<Interval> employeeFreeTime(vector<vector<Interval>>& schedule)
    {
        vector<Interval> results;
        priority_queue<Employee*, std::vector<Employee*>, CompareEmployeePointers> employee_heap;

        for (int i = 0; i < schedule.size(); ++i)
        {
            Employee* employee = new Employee(std::move(schedule.at(i)));
            employee_heap.push(employee);
        }

        // last_start tracks the earliest start time encountered so far (moving backwards)
        int last_start = employee_heap.top()->last_start();
        
        while (employee_heap.size() > 0)
        {
            Employee* employee = employee_heap.top();
            employee_heap.pop();

            Interval interval = employee->schedule.back();
            employee->schedule.pop_back();

            if (employee->schedule.size() > 0)
            {
                employee_heap.push(employee);
            }
            else
            {
                delete employee;
            }

            if (interval.end < last_start)
            {
                // There is a gap between the end of this interval and the start of the next (later) one
                results.push_back(Interval(interval.end, last_start));
            }
            
            // Update last_start to the smallest start time seen so far to find the next possible gap
            if (interval.start < last_start) {
                last_start = interval.start;
            }
        }

        // Since we processed backwards, we need to reverse to return in sorted order
        reverse(results.begin(), results.end());
        return results;
    }
};