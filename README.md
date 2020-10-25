# calc-deploy
A calculator application involving unit tests and ci/cd


## Jenkins File

The Jenkins file does the following

1. Pull the .net core 3.1 docker image 
2. Pull from the repository
3. Restore and Build the project
4. Run unit tests
5. Pack the project with version number equivalent to the build number
6. Publsh a local nupkg
