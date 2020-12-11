#include <iostream>
#include <vector>
#include <string>
#include <set>

using namespace std;

void mutate(vector<string> &arr) {
    int n = arr.size();
    int m = arr[0].size();
    vector<int> dx = {1, 1, 1, 0, 0, -1, -1, -1};
    vector<int> dy = {1, -1, 0, 1, -1, 1, -1, 0};
    vector<string> newArr = vector<string>(arr);
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < m; ++j) {
            int occupied = 0;
            for (int q = 0; q < dx.size(); ++q) {
                int toX = i + dx[q];
                int toY = j + dy[q];
                if (toX >= 0 && toX < n && toY >= 0 && toY < m) {
                    occupied += arr[toX][toY] == '#';
                }
            }
            if (arr[i][j] == 'L' && occupied == 0) {
                newArr[i][j] = '#';
            } else if (arr[i][j] == '#' && occupied >= 4) {
                newArr[i][j] = 'L';
            }

        }
    }

    arr = newArr;
}

void advancedMutate(vector<string> &arr) {
    int n = arr.size();
    int m = arr[0].size();
    vector<int> dx = {1, 1, 1, 0, 0, -1, -1, -1};
    vector<int> dy = {1, -1, 0, 1, -1, 1, -1, 0};
    vector<string> newArr = vector<string>(arr);
    for (int i = 0; i < n; ++i) {
        for (int j = 0; j < m; ++j) {
            int occupied = 0;
            for (int q = 0; q < dx.size(); ++q) {
                int toX = i + dx[q];
                int toY = j + dy[q];
                bool found = false;
                while (toX >= 0 && toX < n && toY >= 0 && toY < m) {
                    if (arr[toX][toY] == '#') {
                        found = true;
                        break;
                    } else if (arr[toX][toY] == 'L') {
                        break;
                    }
                    toX += dx[q];
                    toY += dy[q];
                }
                occupied += found;
            }
            if (arr[i][j] == 'L' && occupied == 0) {
                newArr[i][j] = '#';
            } else if (arr[i][j] == '#' && occupied >= 5) {
                newArr[i][j] = 'L';
            }
        }
    }

    arr = newArr;
}

void basicPart() {
    vector<string> arr;
    for (int i = 0; i < 98; ++i) {
        string s;
        cin >> s;
        arr.push_back(s);
    }

    set<vector<string>> history;
    history.insert(arr);
    mutate(arr);
    while (!history.count(arr)) {
        history.insert(arr);
        mutate(arr);
    }

    int res = 0;
    for (int i = 0; i < arr.size(); ++i) {
        for (int j = 0; j < arr[0].size(); ++j) {
            res += arr[i][j] == '#';
        }
    }

    cout << res;
}

void advancedPart() {
    vector<string> arr;
    for (int i = 0; i < 98; ++i) {
        string s;
        cin >> s;
        arr.push_back(s);
    }

    set<vector<string>> history;
    history.insert(arr);
    mutate(arr);
    while (!history.count(arr)) {
        history.insert(arr);
        advancedMutate(arr);
    }

    int res = 0;
    for (int i = 0; i < arr.size(); ++i) {
        for (int j = 0; j < arr[0].size(); ++j) {
            res += arr[i][j] == '#';
        }
    }

    cout << res;
}

int main() {
    advancedPart();
    return 0;
}
