using System.Collections.Generic;
using System.Linq;

namespace UsStateMapper {
  public class StateNameLookupBuilder {
    private readonly IStateRepository stateRepository;

    public StateNameLookupBuilder(IStateRepository stateRepository) {
      this.stateRepository = stateRepository;
    }

    public Dictionary<string, string> Create() {
      var states = stateRepository.GetAll();
      return states.ToDictionary(s => s.Name.ToLower(), s => s.Name);
    }
  }
}