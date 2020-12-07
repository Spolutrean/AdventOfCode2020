#include <iostream>
#include <string>
#include <vector>

using namespace std;

int getSeatId(string s) {
    int d = 0, u = 128;
    int l = 0, r = 8;
    for(int i = 0; i < 10; ++i) {
        if (i < 7) {
            if (s[i] == 'B') {
                d = (u + d) >> 1;
            } else {
                u = (u + d) >> 1;
            }
        } else {
            if (s[i] == 'R') {
                l = (l + r) >> 1;
            } else {
                r = (l + r) >> 1;
            }
        }
    }

    //cout << d << " " << l << "\n";
    return d * 8 + l;
}

void advancedPart() {
    vector<int> used(128 * 8, false);
    for(int i = 0; i < 826; ++i) {
        string s;
        cin >> s;
        used[getSeatId(s)] = true;
    }

    for(int i = 8; i < 127 * 8; ++i) {
        if(!used[i] && used[i - 1] && used[i + 1]) {
            cout << i << "\n";
        }
    }
}

void basicPart() {
    int ans = -1;
    for(int i = 0; i < 826; ++i) {
        string s;
        cin >> s;
        ans = max(ans, getSeatId(s));
    }

    cout << ans;
}

int main() {
    //basicPart();
    advancedPart();
    return 0;
}
