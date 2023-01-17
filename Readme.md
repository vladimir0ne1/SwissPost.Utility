# Overview

This project contains Utility to convert SwissPost Street Directory database file into GeoJSON format.

# Usage

1. Clone solution.
1. Go to `SwissPost.Utility` folder
1. Set `SourceFilePath` in `appsettings.json`
1. Update other settings if need (see below description - section `Config options`).
1. Optional: Run Ascarix.GeoApi and redirect output to file, it saves a lot of time. Example: `.\Ascarix.GeoApi.exe > out_log.txt`
1. Build solution: `dotnet build`
1. Run utility: `dotnet run`

# Configuration

Configuration file path: `SwissPost.Utility/appsettings.json`

## Config options:

- UseMockGeoApi - specifies if mock api should be used or not.
- GeoApiUrl - **base** url to Ascarix.GeoApi
- ParallelGeoApiRequests - number of parallel api requests to GeoApi
- SourceFilePath - Absolute path to the source file

# Architectural notes

## SwissPost.StreetDirectory

Contains StreetDirectory database model. All data reads into memory as we don't know if it is always ordered correctly to avoid broken foreign keys.
Key concept is that entities collections are stored as dictionaries where key is entity primary key.

## Ascarix.GeoApi

Contains ApiClient to fetch GeoApi data.

`MockGeoApiClientHandler` added for development and unit-testing.

## SwissPost.Tests

Contains some tests used during development.

## SwissPost.Utility

Entry point and main algorithm that converts Database Model into GeoJson.

## External Libraries used:

- CsvHelper - to read source model
- GeoJSON.Text - for working with GeoJSON and use native json serializer.
- NUnit - for unit tests

# Further improvements steps

- Read source file in parallel chunks
- Store Geo location in persistent storage and/or cache / wrap GeoCoordinatesProvider with caching mechanism
- Add logger instead of using Console
- Add corner-cases handlers:
  - Inconsistent source data, for example broken foreign keys
  - BadRequest from GeoApi 





