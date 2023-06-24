namespace SermonCentral.Spark.Models;

public class ModelStateValidation
{
    public bool Valid { get; set; }
    public IEnumerable<ModelStateError> Errors { get; set; }
}
    
public class ModelStateError
{
    public string Field { get; set; }
    public IEnumerable<string> Errors { get; set; }
}