#include <iostream>
#include <vector>

using namespace std;

void advancedPart() {
    vector<long long> st;
    int n = 1000;
    for(int i = 0; i < n; ++i) {
        long long x;
        cin >> x;
        st.push_back(x);
    }
    for(int l = 0; l < n; ++l) {
        for(int r = l; r < n; ++r) {
            long long sum = 0, mn = 1e18, mx = -1e18;
            for(int i = l; i <= r; ++i) {
                sum += st[i];
                mn = min(mn, st[i]);
                mx = max(mx, st[i]);
            }
            if(sum == 26134589) {
                cout << mn + mx << "\n";
                return;
            }
        }
    }
    cout << "Sad story :C";
}

void basicPart() {
    vector<long long> st;
    for(int i = 0; i < 1000; ++i) {
        long long x;
        cin >> x;
        if(i < 25) {
            st.push_back(x);
        } else {
            bool ok = false;
            for(int j = 0; j < st.size() && !ok; ++j) {
                for(int k = j + 1; k < st.size() && !ok; ++k) {
                    if(st[j] + st[k] == x) ok = true;
                }
            }
            if(ok) {
                st.erase(st.begin());
                st.push_back(x);
            } else {
                cout << x;
                return;
            }
        }
    }
}

int main() {
    advancedPart();
    return 0;
}
