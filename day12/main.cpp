#include <iostream>
#include <vector>
#include <string>
#include <functional>

using namespace std;

void advancedPart() {
    pair<int,int> xy = {0, 0}, v = {10, 1};

    for(int i = 0; i < 790; ++i) {
        string s;
        cin >> s;
        char command = s[0];
        int num = 0;
        for(int j = 1; j < s.size(); ++j)
        {
            num *= 10;
            num += s[j] - '0';
        }

        if(command == 'N') {
            v.second += num;
        } else if(command == 'S') {
            v.second -= num;
        } else if(command == 'E') {
            v.first += num;
        } else if(command == 'W') {
            v.first -= num;
        } else if(command == 'F') {
            xy.first += v.first * num;
            xy.second += v.second * num;
        } else if(command == 'R') {
            int w = num / 90;
            while(w) {
                w--;
                int px = v.first, py = v.second;
                v.first = py;
                v.second = -px;
            }
        } else if(command == 'L') {
            int w = num / 90;
            while(w) {
                w--;
                int px = v.first, py = v.second;
                v.first = -py;
                v.second = px;
            }
        }
        cout << xy.first << " " << xy.second << " " << v.first << " " << v.second << "\n";
    }

    cout << xy.first << " " << xy.second << "\n";
    cout << abs(xy.first) + abs(xy.second);
}

void basicPart() {
    vector<pair<int,int>> directions = {{1, 0}, {0, -1}, {-1, 0}, {0, 1}}; //ESWN
    int di = 0;
    pair<int,int> xy = {0, 0};

    for(int i = 0; i < 790; ++i) {
        string s;
        cin >> s;
        char command = s[0];
        int num = 0;
        for(int j = 1; j < s.size(); ++j)
        {
            num *= 10;
            num += s[j] - '0';
        }

        if(command == 'N') {
            xy.second += num;
        } else if(command == 'S') {
            xy.second -= num;
        } else if(command == 'E') {
            xy.first += num;
        } else if(command == 'W') {
            xy.first -= num;
        } else if(command == 'F') {
            xy.first += directions[di].first * num;
            xy.second += directions[di].second * num;
        } else if(command == 'R') {
            int w = num / 90;
            di = (di + w) % 4;
        } else if(command == 'L') {
            int w = num / 90;
            di = (di - w + 64) % 4;
        }
    }

    cout << xy.first << " " << xy.second << "\n";
    cout << abs(xy.first) + abs(xy.second);
}

int main() {
    advancedPart();
    return 0;
}
