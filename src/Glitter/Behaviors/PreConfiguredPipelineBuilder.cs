// namespace Glitter.Behaviors;
//
// /// <summary>
// /// Represents a pipeline for processing requests.
// /// </summary>
// /// <typeparam name="TRequest">Specifies the type of the request.</typeparam>
// public class PreConfiguredPipelineBuilder<TRequest>
//     : IPipelineBuilder<TRequest>
// {
//     private readonly IServiceProvider? _serviceProvider;
//     private readonly List<Type> _pipeTypes = new();
//     
//     /// <summary>
//     /// Initializes a new instance of the <see cref="PreConfiguredPipelineBuilder{TRequest}"/> class.
//     /// </summary>
//     /// <param name="serviceProvider">A provider for retrieving services.</param>
//     public PreConfiguredPipelineBuilder(IServiceProvider? serviceProvider = null) =>
//         _serviceProvider = serviceProvider;
//     
//     /// <inheritdoc />
//     public IPipelineBuilder<TRequest> Add<TPipe>()
//         where TPipe : IPipe<TRequest>
//     {
//         _pipeTypes.Add(typeof(TPipe));
//         return this;
//     }
//     
//     /// <summary>
//     /// Builds the pipeline.
//     /// </summary>
//     /// <returns>The head of the pipeline.</returns>
//     protected internal virtual IPipe<TRequest> Build()
//     {
//         Type[] pipeTypes = _pipeTypes.ToArray();
//         var pipes = new IPipe<TRequest>?[pipeTypes.Length];
//         for (int i = 0; i < pipeTypes.Length; i++)
//         {
//             Type pipeType = pipeTypes[i];
//             IPipe<TRequest>? pipe = _serviceProvider is null
//                 ? Activator.CreateInstance(pipeType) as IPipe<TRequest>
//                 : ActivatorUtilities.CreateInstance(_serviceProvider, pipeType) as IPipe<TRequest>;
//             
//             pipes[i] = pipe;
//         }
//         
//         for (var i = 0; i < pipes.Length - 1; i++)
//             pipes[i].Successor = pipes[i + 1];
//         
//         return pipes[0];
//     }
// }