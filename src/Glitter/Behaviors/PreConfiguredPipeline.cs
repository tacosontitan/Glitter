// namespace Glitter.Behaviors;
//
// /// <summary>
// /// Represents a pipeline for processing requests.
// /// </summary>
// /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
// public abstract class PreConfiguredPipeline<TRequest>
//     : IPipeline<TRequest>
// {
//     private IPipe<TRequest>? _head;
//     private readonly IServiceProvider? _serviceProvider;
//     
//     /// <summary>
//     /// Initializes a new instance of the <see cref="PreConfiguredPipeline{TRequest}"/> class.
//     /// </summary>
//     /// <param name="serviceProvider">A provider for retrieving services.</param>
//     public PreConfiguredPipeline(IServiceProvider? serviceProvider = null) =>
//         _serviceProvider = serviceProvider;
//     
//     public Task Process(TRequest request, CancellationToken cancellationToken = default)
//     {
//         if (!TryCompile())
//             throw new InvalidOperationException("Unable to compile the pipeline.");
//         
//         return _head.Process(request, cancellationToken);
//     }
//     
//     protected abstract void Configure(IPipelineBuilder<TRequest> pipeline);
//
//     private bool TryCompile()
//     {
//         if (_head is not null)
//             return true;
//         
//         var builder = new PreConfiguredPipelineBuilder<TRequest>(_serviceProvider);
//         Configure(builder);
//         
//         _head = builder.Build();
//     }
// }

