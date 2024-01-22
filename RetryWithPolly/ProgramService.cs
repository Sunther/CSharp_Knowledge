using Polly.Registry;

public class ProgramService : IProgramService
{
    private readonly ResiliencePipelineRegistry<string> _pipelineProvider;

    public ProgramService(ResiliencePipelineRegistry<string> pipelineProvider)
    {
        _pipelineProvider = pipelineProvider;
    }

    public void Run()
    {
        var pipeline = _pipelineProvider.GetPipeline<string>(Program.PipelineTag);
        _ = pipeline.Execute<string>(() => Method());
    }

    public static string Method()
    {
        throw new NotImplementedException();
    }
}

public interface IProgramService
{
    void Run();
}