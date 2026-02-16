using System.ComponentModel.DataAnnotations;

public class Bridge
{
  public int BridgeId { get; set; }

  [Required]
  public string? BridgeName { get; set; }

  [Required]
  [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be at least {1}")]
  public double? WeightLimitTons { get; set; }

  [Required]
  [Range(1, int.MaxValue, ErrorMessage = "Value for {0} must be at least {1}")]
  public double? HeightInFeet { get; set; }
}