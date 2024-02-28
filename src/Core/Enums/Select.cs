using System.ComponentModel.DataAnnotations;

namespace Core.Enums;

public enum Select
{
    /// <summary>
    /// Неопределено 
    /// </summary>
    [Display(Name = "Неопределено")]
    Unknown = 0,

    /// <summary>
    /// Первая опция 
    /// </summary>
    [Display(Name = "Первая опция")]
    FirstOption = 10,

    /// <summary>
    /// Вторая опция 
    /// </summary>
    [Display(Name = "Вторая опция")]
    SecondOption = 20,

    /// <summary>
    /// Третья опция 
    /// </summary>
    [Display(Name = "Третья опция")]
    ThirdOption = 30
}