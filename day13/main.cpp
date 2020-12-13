#include <iostream>
#include <vector>
#include <string>

using namespace std;

void basicPart() {
    int n;
    string s;
    cin >> n >> s;
    s += ',';
    vector<int> nums;
    int cur = 0;
    for (char c : s) {
        if (c == 'x') continue;
        if (c == ',') {
            if (cur != 0) nums.push_back(cur);
            cur = 0;
        } else {
            cur *= 10;
            cur += c - '0';
        }
    }

    long long delta = 1e9, busNumber;
    for (int x : nums) {
        int d = ceil(n * 1. / x) * x - n;
        if (d < delta) {
            delta = d;
            busNumber = x;
        }
    }

    cout << busNumber << " " << delta << "\n";
    cout << busNumber * delta;
}

void advancedPart() {
    int n;
    string s;
    cin >> n >> s;
    s += ',';
    vector<int> nums;
    int cur = 0;
    for (char c : s) {
        if (c == 'x') continue;
        if (c == ',') {
            nums.push_back(cur);
            cur = 0;
        } else {
            cur *= 10;
            cur += c - '0';
        }
    }

    vector<pair<int, int>> ans;
    for (int i = 0; i < nums.size(); ++i) {
        int x = nums[i];
        if (x != 0) {
            ans.push_back({x, (x - i) % x});
        }
    }
    for (pair<int, int> x : ans) {
        cout << x.first << " " << x.second << ", ";
    }

    // put output to the online solver - https://abakbot.ru/online-16/331-chislo-china
}

int main() {
    //basicPart();
    advancedPart();
    return 0;
}
