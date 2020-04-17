# CodeTest-CubicWeight
a code test project for Kogan

# Test Description

## Challenge Description
Using the provided (paginated) API, find the average cubic weight for all products in the "Air Conditioners" category.

Cubic weight is calculated by multiplying the length, height and width of the parcel. The result is then multiplied by the industry standard cubic weight conversion factor of 250.

## API Endpoint
http://wp8m3he1wt.s3-website-ap-southeast-2.amazonaws.com/api/products/1

## Cubic Weight Example
A parcel measuring 40cm long (0.4m) x 20cm high (0.2m) x 30cm wide (0.3m) is equal to 0.024 cubic metres.
Multiplied by the conversion factor of 250 gives a cubic weight of 6kg.

0.4m x 0.2m x 0.3m = 0.024m3
0.024m3 x 250 = 6kg

## Assume that
- All dimensions are provided in centimetres.
- All weights are provided in grams.

## Submission
- You must submit setup instructions with your solution, and specify language used eg: Language: Javascript
- Zip/tarball up your whole challenge working directory with your source code and any other files you feel are necessary.
- Reply to dev.jobs@kogan.com with a link to your source code (eg via Dropbox/Google Drive/Github/etc) by Sun, 19 Apr 2020 23:59:59 +1000.

# Env:

- VS Studio 2019 for Mac
- .Net Core 3.1
- XUnit
- Github

# Setup
Download source code from https://github.com/LeonLiu-Stone/CodeTest-CubicWeight

## run in command line
    1. Open a Terminal in Mac, or command line in Windows
    2. Direct to project folder, then run the commands below:
        cd CubicWeight.UI
        dotnet build
        dotnet run
    3. then, in the output screen, the average cubic weight has been printed at the last line
## run in Visual Studio
    1. open the CubicWeight.sln file in the project folder
    2. set CubicWeight.UI as startup project
    3. run in debug as normal .net project

NB: it also prints all endpoints and product titles of air conditions