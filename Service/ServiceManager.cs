using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly IQotdService _qotdService;

    public ServiceManager(IQotdService qotdService)
    {
        _qotdService = qotdService;
    }

    public IQotdService QotdService => _qotdService;
}