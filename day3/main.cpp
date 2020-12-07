#include <iostream>
#include <vector>
#include <string>

using namespace std;

void basicPart() {
    int n = 323;
    vector<string> arr;
    for(int i = 0; i < n; ++i) {
        string s;
        cin >> s;
        arr.push_back(s);
    }
    int m = arr[0].size();
    int x = 0, y = 0, cnt = 0;
    while(x < n) {
        y %= m;
        cnt += arr[x][y] == '#';
        x += 1;
        y += 3;
    }

    cout << cnt;
}

void advancedPart() {
    int n = 323;
    vector<string> arr;
    for(int i = 0; i < n; ++i) {
        string s;
        cin >> s;
        arr.push_back(s);
    }
    int m = arr[0].size();
    vector<pair<int,int>> d = {{1, 1}, {1, 3}, {1, 5}, {1, 7}, {2,1}};
    long long p = 1;
    for(auto delta : d) {
        int x = 0, y = 0;
        long long cnt = 0;
        while(x < n) {
            y %= m;
            cnt += arr[x][y] == '#';
            x += delta.first;
            y += delta.second;
        }
        p *= cnt;
    }

    cout << p;
}

int main() {
    basicPart();
    advancedPart();
    return 0;
}
