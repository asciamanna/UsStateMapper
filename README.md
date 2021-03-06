# U.S. State Mapper  [![Build status](https://ci.appveyor.com/api/projects/status/j2rbdbq7l9g6egl7?svg=true)](https://ci.appveyor.com/project/asciamanna/usstatemapper) 
This library maps an input string into a U.S. State, a U.S. territory, or the District of Columbia.

## Current Capabilities

Takes as inputs:

* State names (including territories and federal districts)
* USPS two-letter abbreviations
* ISO 2+2-letter codes from [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) _(e.g., US-PA)_ 
* ANSI two-digit codes _(e.g., 04 for Arizona)_ 

Returns:

* Official U.S. State name

## TODO
There are several features I will be building out over time

* Ability to convert an input string into the USPS recognized two-letter state abbreviation.
* Accept US Coast Guard two-letter abbreviations as input.
* Accept Old GPO state abbreviations as input
* Accept AP stylebook abbreviations as input
* Accept other recognized state abbreviations as inputs.
* Fuzzy match strings for state names.

## Usage

```
var stateMapper = new StateMapper();
var result = stateMapper.ToState("PA"); // result is "Pennsylvania"  
result = stateMapper.ToState("Newyork"); // result is "New York"  
result = stateMapper.ToState("  Utah "); // result is "Utah"
result = stateMapper.ToState("US-ME"); // result is "Maine"
result = stateMapper.ToState("04"); // result is "Arizona"  
  
```
## License
This software is licensed under the MIT license. It can be found included in this repository [here](./LICENSE).
