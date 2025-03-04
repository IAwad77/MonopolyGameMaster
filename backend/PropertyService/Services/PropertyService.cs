using PropertyService.Models;
using System.Collections.Generic;
using System.Linq;

namespace PropertyService.Services;

public class PropertyService
{
    private readonly List<Property> _props = new();

    public List<Property> GetAll()            => _props;
    public Property? GetById(int id)          => _props.FirstOrDefault(p=>p.Id==id);
    public void Add(Property p)               => _props.Add(p);
    public void Update(Property p)
    {
        var idx=_props.FindIndex(x=>x.Id==p.Id);
        if(idx!=-1) _props[idx]=p;
    }
    public void Delete(int id)                => _props.RemoveAll(p=>p.Id==id);
}
