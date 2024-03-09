using Assignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Services
{
    public class MockDataStore : IDataStore<ControlTypes>
    {
        readonly List<ControlTypes> controls;

        public MockDataStore()
        {
            controls = new List<ControlTypes>()
            {
                new ControlTypes { Id = Guid.NewGuid().ToString(), Name = "Entry",  },
                new ControlTypes { Id = Guid.NewGuid().ToString(), Name = "Editor" },
                new ControlTypes { Id = Guid.NewGuid().ToString(), Name = "Picker" },
                new ControlTypes { Id = Guid.NewGuid().ToString(), Name = "CheckBox" },
                new ControlTypes { Id = Guid.NewGuid().ToString(), Name = "Switch" },
                new ControlTypes { Id = Guid.NewGuid().ToString(), Name = "Button" }
            };
        }

        public async Task<ControlTypes> GetControlAsync(string Name)
        {
            return await Task.FromResult(controls.FirstOrDefault(s => s.Name == Name));
        }

        public async Task<IEnumerable<ControlTypes>> GetControlsAsync()
        {
            return await Task.FromResult(controls);
        }
    }
}