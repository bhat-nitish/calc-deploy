# calc-deploy
A calculator application involving unit tests and ci/cd

## Design Considerations

1. Double datatype used instead of Decimal for performance (precision vs performance tradeoff).
2. Strategy Pattern used to easily add functionality without modifying other classes.
3. Parallel foreach used for Additions and Multiplication as they do not need order to be maintained.
4. The Division and Multiply operations are implemented as Parallel Aggregates but with order.
5. The Calculator.API project acts as an entry point and is lightweight.
6. The Calculator.API project delegates responsibility of computation to the Calculator.Service project which houses the logic for computation.
7. The Calculator.API.Test project covers unit testing for delegation and verifying success , status code and result.
8. The Calculator.Service.Test is covers unit testing for different strategies and specific usecases (example : dividebyzero for division strategy).
9. All the endpoints are asynchronous.
10. Moq is used for mocking interfaces in Calculator.API.Test. NUnit framework is used.

## Jenkins File

The Jenkins file does the following

1. Pull the .net core 3.1 docker image 
2. Pull from the repository
3. Restore and Build the project
4. Run unit tests
5. Pack the project with version number equivalent to the build number
6. Publsh a local nupkg

## Docker File

The project is also containerized by using Docker. The docker file can be run independently.
