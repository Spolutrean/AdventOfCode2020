#include <iostream>
#include <unordered_set>

using namespace std;

void basicTask() {
    unordered_set<int> st;
    for(int i = 0; i < 200; ++i) {
        int x;
        cin >> x;
        if(st.count(2020 - x)) {
            cout << x * (2020 - x);
            return;
        }
        st.insert(x);
    }
}

void advancedTask() {
    vector<int> st;
    for(int i = 0; i < 200; ++i) {
        int x;
        cin >> x;
        st.push_back(x);
    }

    for(int i = 0; i < st.size(); ++i) {
        for(int j = i + 1; j < st.size(); ++j) {
            for(int k = j + 1; k < st.size(); ++k) {
                if(st[i] + st[j] + st[k] == 2020) {
                    cout << st[i] * st[j] * st[k];
                    return;
                }
            }
        }
    }
}

int main() {
    basicTask();
    advancedTask();
    return 0;
}
