using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Interfaces
{
    public interface IAuditService
    {
        Task LogActionAsync(
            string action,
            string entityName,
            string entityId,
            object? oldValues,
            object? newValues,
            bool isSuccess = true,
            string failureReason = "");
    }
}
