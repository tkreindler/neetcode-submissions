class Solution {
public:
    bool canFinish(
        int numCourses, const vector<vector<int>>& prerequisites)
    {
        unordered_set<int> visited;
        visited.reserve(numCourses);

        unordered_set<int> stack_visited;
        stack_visited.reserve(numCourses);

        unordered_map<int, vector<int>> edges;
        edges.reserve(prerequisites.size());

        for (const vector<int>& prerequisite : prerequisites)
        {
            edges[prerequisite.at(0)].push_back(prerequisite.at(1));
        }

        for (int i = 0; i < numCourses; ++i)
        {
            if (visited.find(i) == visited.end()) {
                if (this->hasCycle(visited, stack_visited, edges, i))
                {
                    return false;
                }
            }
        }
        
        return true;
    }

    bool hasCycle(
        unordered_set<int>& visited,
        unordered_set<int>& stack_visited,
        const unordered_map<int, vector<int>>& edges,
        int current)
    {
        if (stack_visited.count(current)) return true;
        if (visited.count(current)) return false;

        visited.insert(current);
        stack_visited.insert(current);

        auto iter = edges.find(current);
        if (iter != edges.end()) {
            for (int neighbor : iter->second) {
                if (hasCycle(visited, stack_visited, edges, neighbor)) {
                    return true;
                }
            }
        }

        stack_visited.erase(current);
        return false;
    }
};