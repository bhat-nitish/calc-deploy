# calc-deploy
A calculator application involving unit tests and ci/cd


## Jenkins File

The Jenkins file does the following

### Pull the .net core 3.1 docker image 
### Pull from the repository
### Restore and Build the project
### Run unit tests
### Pack the project with version number equivalent to the build number
### Publsh a local nupkg
