# AltTester Sample Project 

This repository contains a **sample automated test project** for `AltTester` framework,  
demonstrating how to write and run UI tests for Unity applications (PC, mobile and web).  

The project includes a **simple game** with:
- One button
- A counter of button click

Automated tests check:
1. If the button is clickable
2. If the counter increments correctly after clicks
3. If multiple clicks produce the expected counter value

##Requriements to launch automated test:
- Unity editor 2022.3.62f1 version 
- AltTester Desktop aplication latest version 
- AltTester user profile and License key 

Test located \Assets\AltTester\Editor\Tests

##How to Run the Tests
1. Add this prject map in **Unity Editor**
3. Start **AltTester Desktop** on localhost `127.0.0.1` and default port `13000`
4. In Unity, open qa-engineer-test-master project
5. Open AltTester window:
   - `AltTester > AltTester Editor`
6. Run the test suite
   - Select all tests from test list
   - Select `Editor` From Platform list
   - Select `Play in editor` (wait to fully load game)
   - Click `Run all tests`
   - Wait till popup window shows test status