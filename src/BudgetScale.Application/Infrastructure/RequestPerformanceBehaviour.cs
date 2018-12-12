using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BudgetScale.Domain.Entities;
using BudgetScale.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BudgetScale.Application.Infrastructure
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ApplicationDbContext _context;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger, ApplicationDbContext context)
        {
            _timer = new Stopwatch();
            _context = context;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 500)
            {
               //var name = typeof(TRequest).Name;

               // var desc = string.Format(
               //     "BudgetScale Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}", name,
               //     _timer.ElapsedMilliseconds, request);
               // var longRequest = new LongRequest
               // {
               //     ElapsedMilliseconds =  _timer.ElapsedMilliseconds.ToString(),
               //     Name = name,
               //     RequestDescription = desc
               // };
                
               // _logger.LogWarning("BudgetScale Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}", name, _timer.ElapsedMilliseconds, request);

               // _context.LongRequests.Add(longRequest);
               // await _context.SaveChangesAsync(cancellationToken);
                
            }

            return response;
        }
        
    }
}