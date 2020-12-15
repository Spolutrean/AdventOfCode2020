#include <iostream>
#include <vector>
#include <string>
#include <map>
#include <unordered_map>

using namespace std;

void basicPart() {
    map<int, int> mp;
    vector<int> history = {0,13,1,16,6,17};
    for(int i = 0; i < history.size() - 1; ++i) {
        mp[history[i]] = i;
    }
    for(int i = history.size() - 1; i < 2020; ++i) {
        int x = history.back();
        if (!mp.count(x)) {
            history.push_back(0);
        } else {
            history.push_back(i - mp[x]);
        }
        mp[x] = i;
    }

    for(int i = 0; i < history.size(); ++i) {
        cout << history[i] << " ";
    }

    cout << "\n" << history[2019];

}

void advancedPart() {
    unordered_map<int, int> mp;
    vector<int> history = {0,13,1,16,6,17};
    for(int i = 0; i < history.size() - 1; ++i) {
        mp[history[i]] = i;
    }

    int prev = history.back();

    for(int i = history.size() - 1; i < 30000000 - 1; ++i) {
        //cout << prev << "\n";
        int x = prev;
        if (!mp.count(x)) {
            prev = 0;
        } else {
            prev = i - mp[x];
        }
        mp[x] = i;
    }

    cout << "\n" << prev;
}

int main() {
    //basicPart();
    advancedPart();
    return 0;
}
