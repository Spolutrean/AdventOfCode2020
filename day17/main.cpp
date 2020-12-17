#include <iostream>
#include <set>
#include <string>
#include <vector>

using namespace std;

void basicPart() {
    vector<string> input = {"..#..#.#",
                            "##.#..#.",
                            "#....#..",
                            ".#..####",
                            ".....#..",
                            "...##...",
                            ".#.##..#",
                            ".#.#.#.#"};


//    vector<string> input = {".#.",
//                            "..#",
//                            "###"};

    int l = -20, r = 20;
    set<pair<int, pair<int, int>>> coords;
    for (int i = 0; i < input.size(); ++i) {
        for (int j = 0; j < input[i].size(); ++j) {
            if (input[i][j] == '#') {
                coords.insert({0, {i, j}});
            }
        }
    }

    for (int step = 1; step <= 6; ++step) {
        set<pair<int, pair<int, int>>> newCoords;
        for (int x = l; x <= r; ++x) {
            for (int y = l; y <= r; ++y) {
                for (int z = l; z <= r; ++z) {
                    int cnt = 0;
                    for (int dx : {-1, 0, 1}) {
                        for (int dy : {-1, 0, 1}) {
                            for (int dz : {-1, 0, 1}) {
                                if (!dx && !dy && !dz) continue;
                                cnt += coords.count({z + dz, {x + dx, y + dy}});
                            }
                        }
                    }
                    if (coords.count({z, {x, y}}) && (cnt == 2 || cnt == 3)) {
                        newCoords.insert({z, {x, y}});
                    }
                    if (!coords.count({z, {x, y}}) && cnt == 3) {
                        newCoords.insert({z, {x, y}});
                    }
                }
            }
        }
        coords = newCoords;
        /*
        cout << "Step number " << step << ": \n";
        for(int z = -2; z <= 2; ++z) {
            cout << "z = " << z << " :\n";
            for(int x = -5; x <= 5; ++x) {
                for(int y = -5; y <= 5; ++y) {
                    cout << (coords.count({z, {x, y}}) ? '#' : '.') << " ";
                }
                cout << "\n";
            }
            cout << "\n";
        }
         */
    }

    cout << coords.size();
}

void advancedPart() {
    vector<string> input = {"..#..#.#",
                            "##.#..#.",
                            "#....#..",
                            ".#..####",
                            ".....#..",
                            "...##...",
                            ".#.##..#",
                            ".#.#.#.#"};


//    vector<string> input = {".#.",
//                            "..#",
//                            "###"};

    int l = -20, r = 20;
    set<pair<pair<int, int>, pair<int, int>>> coords;//x,y,z,w
    for (int i = 0; i < input.size(); ++i) {
        for (int j = 0; j < input[i].size(); ++j) {
            if (input[i][j] == '#') {
                coords.insert({{i, j},
                               {0, 0}});
            }
        }
    }

    for (int step = 1; step <= 6; ++step) {
        set<pair<pair<int, int>, pair<int, int>>> newCoords;
        for (int x = l; x <= r; ++x) {
            for (int y = l; y <= r; ++y) {
                for (int z = l; z <= r; ++z) {
                    for (int w = l; w <= r; ++w) {
                        int cnt = 0;
                        for (int dx : {-1, 0, 1}) {
                            for (int dy : {-1, 0, 1}) {
                                for (int dz : {-1, 0, 1}) {
                                    for (int dw : {-1, 0, 1}) {
                                        if (!dx && !dy && !dz && !dw) continue;
                                        cnt += coords.count({{x + dx, y + dy},
                                                             {z + dz, w + dw}});
                                    }
                                }
                            }
                        }
                        if (coords.count({{x, y},
                                          {z, w}}) && (cnt == 2 || cnt == 3)) {
                            newCoords.insert({{x, y},
                                              {z, w}});
                        }
                        if (!coords.count({{x, y},
                                           {z, w}}) && cnt == 3) {
                            newCoords.insert({{x, y},
                                              {z, w}});
                        }
                    }
                }
            }
        }
        coords = newCoords;
        /*
        cout << "Step number " << step << ": \n";
        for(int z = -2; z <= 2; ++z) {
            cout << "z = " << z << " :\n";
            for(int x = -5; x <= 5; ++x) {
                for(int y = -5; y <= 5; ++y) {
                    cout << (coords.count({z, {x, y}}) ? '#' : '.') << " ";
                }
                cout << "\n";
            }
            cout << "\n";
        }
         */
    }

    cout << coords.size();
}


int main() {
    //basicPart();
    advancedPart();
    return 0;
}
