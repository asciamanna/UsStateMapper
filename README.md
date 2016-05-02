# U.S. State Mapper 
This library maps an input string into a U.S. State, a U.S. territory, or the District of Columbia.

## Current Capabilities

Takes as inputs:

* State names (including territories and federal districts)
* USPS two-letter abbreviations
* ISO 2+2-letter codes from [ISO 3166-2](https://en.wikipedia.org/wiki/ISO_3166-2) _(e.g., US-PA)_ 

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
result = stateMapper.ToState("Newyork"); //result is "New York"  
result = stateMapper.ToState("  Utah "); // result is "Utah"  
```

