using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace UsStateMapper {
  public interface IStateRepository {
    List<State> GetAll();
  }

  public class StateRepository : IStateRepository {
    public List<State> GetAll() {
      var states = new List<State>();
      using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("UsStateMapper.states.json"))
      using (var reader = new StreamReader(stream)) {
        states = JsonConvert.DeserializeObject<List<State>>(reader.ReadToEnd());
      }
      return states;
    } 
  }
}
