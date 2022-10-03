using acme.sistemas.compracoletiva.core.Base;
using Microsoft.AspNetCore.Mvc.Filters;

namespace acme.sistemas.compracoletiva.api.Configurations.Filtler
{
    public class UnitOfWorkFilter : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            try
            {
                IUnitOfWork baseApplication = (IUnitOfWork)context.HttpContext.RequestServices.GetService(typeof(IUnitOfWork));
                bool salvo = await baseApplication.Commit();
                if (!salvo)
                    throw (new Exception("Problema ao salvar elemento"));
                else
                    await next();
            }
            catch
            {
                throw;
            }
        }
    }
}
