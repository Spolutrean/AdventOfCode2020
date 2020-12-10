#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

void advancedPart() {
    vector<int> arr;
    arr.push_back(0);
    for(int i = 0; i < 98; ++i) {
        int x;
        cin >> x;
        arr.push_back(x);
    }
    sort(arr.begin(), arr.end());
    arr.push_back(arr.back() + 3);
    vector<long long> dp(arr.size());
    dp[0] = 1;
    for(int i = 1; i < arr.size(); ++i) {
        long long sum = 0;
        int j = i - 1;
        while(j >= 0 && arr[i] - arr[j] <= 3) {
            sum += dp[j];
            --j;
        }
        dp[i] = sum;
    }

    for(int i = 0; i < dp.size(); ++i) {
        cout << arr[i] << " " << dp[i] << "\n";
    }

    cout << dp.back();
}

void basicPart() {
    int cnt1 = 0, cnt3 = 0;
    vector<int> arr;
    arr.push_back(0);
    for(int i = 0; i < 98; ++i) {
        int x;
        cin >> x;
        arr.push_back(x);
    }
    sort(arr.begin(), arr.end());
    arr.push_back(arr.back() + 3);
    for(int i = 1; i < arr.size(); ++i) {
        cnt1 += arr[i] - arr[i-1] == 1;
        cnt3 += arr[i] - arr[i-1] == 3;
    }

    cout << cnt1 << " " << cnt3 << "\n";
    cout << cnt1 * cnt3;
}

int main() {
    basicPart();
    advancedPart();
    return 0;
}
