using System.Text.Json;
using MovieApi.Data.Entities;

namespace MovieApi.Tests.SeedData;

public class Movies
{
    public static List<Movie> SeedData => JsonSerializer.Deserialize<List<Movie>>(JsonObject,
        new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        })!;

    /// <summary>
    /// Generate from real data
    /// </summary>
    private static string JsonObject => @"[
      {
        ""releaseDate"": ""2021-12-15T00:00:00"",
        ""title"": ""Spider-Man: No Way Home"",
        ""overview"": ""Peter Parker is unmasked and no longer able to separate his normal life from the high-stakes of being a super-hero. When he asks for help from Doctor Strange the stakes become even more dangerous, forcing him to discover what it truly means to be Spider-Man."",
        ""popularity"": 5083.954,
        ""voteCount"": 8940,
        ""voteAverage"": 8.3,
        ""originalLanguage"": ""en"",
        ""genres"": ""Action, Adventure, Science Fiction"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/1g0dhYtq4irTY1GPXvft6k4YLjm.jpg""
      },
      {
        ""releaseDate"": ""2022-03-01T00:00:00"",
        ""title"": ""The Batman"",
        ""overview"": ""In his second year of fighting crime, Batman uncovers corruption in Gotham City that connects to his own family while facing a serial killer known as the Riddler."",
        ""popularity"": 3827.658,
        ""voteCount"": 1151,
        ""voteAverage"": 8.1,
        ""originalLanguage"": ""en"",
        ""genres"": ""Crime, Mystery, Thriller"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/74xTEgt7R36Fpooo50r9T25onhq.jpg""
      },
      {
        ""releaseDate"": ""2022-02-25T00:00:00"",
        ""title"": ""No Exit"",
        ""overview"": ""Stranded at a rest stop in the mountains during a blizzard, a recovering addict discovers a kidnapped child hidden in a car belonging to one of the people inside the building which sets her on a terrifying struggle to identify who among them is the kidnapper."",
        ""popularity"": 2618.087,
        ""voteCount"": 122,
        ""voteAverage"": 6.3,
        ""originalLanguage"": ""en"",
        ""genres"": ""Thriller"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/vDHsLnOWKlPGmWs0kGfuhNF4w5l.jpg""
      },
      {
        ""releaseDate"": ""2021-11-24T00:00:00"",
        ""title"": ""Encanto"",
        ""overview"": ""The tale of an extraordinary family, the Madrigals, who live hidden in the mountains of Colombia, in a magical house, in a vibrant town, in a wondrous, charmed place called an Encanto. The magic of the Encanto has blessed every child in the family with a unique gift from super strength to the power to heal—every child except one, Mirabel. But when she discovers that the magic surrounding the Encanto is in danger, Mirabel decides that she, the only ordinary Madrigal, might just be her exceptional family's last hope."",
        ""popularity"": 2402.201,
        ""voteCount"": 5076,
        ""voteAverage"": 7.7,
        ""originalLanguage"": ""en"",
        ""genres"": ""Animation, Comedy, Family, Fantasy"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/4j0PNHkMr5ax3IA8tjtxcmPU3QT.jpg""
      },
      {
        ""releaseDate"": ""2021-12-22T00:00:00"",
        ""title"": ""The King's Man"",
        ""overview"": ""As a collection of history's worst tyrants and criminal masterminds gather to plot a war to wipe out millions, one man must race against time to stop them."",
        ""popularity"": 1895.511,
        ""voteCount"": 1793,
        ""voteAverage"": 7,
        ""originalLanguage"": ""en"",
        ""genres"": ""Action, Adventure, Thriller, War"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/aq4Pwv5Xeuvj6HZKtxyd23e6bE9.jpg""
      },
      {
        ""releaseDate"": ""2022-01-07T00:00:00"",
        ""title"": ""The Commando"",
        ""overview"": ""An elite DEA agent returns home after a failed mission when his family makes an unexpected discovery in their house – a stash of money worth $3 million. They soon face the danger and threat of a newly released criminal and his crew, who will do whatever it takes to retrieve the money, including kidnap the agent’s daughters. Stakes are high and lives are at risk in this head-to-head battle as the agent stops at nothing to protect his family against the money-hungry criminals."",
        ""popularity"": 1750.484,
        ""voteCount"": 33,
        ""voteAverage"": 6.6,
        ""originalLanguage"": ""en"",
        ""genres"": ""Action, Crime, Thriller"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/pSh8MyYu5CmfyWEHzv8FEARH2zq.jpg""
      },
      {
        ""releaseDate"": ""2022-01-12T00:00:00"",
        ""title"": ""Scream"",
        ""overview"": ""Twenty-five years after a streak of brutal murders shocked the quiet town of Woodsboro, a new killer has donned the Ghostface mask and begins targeting a group of teenagers to resurrect secrets from the town’s deadly past."",
        ""popularity"": 1675.161,
        ""voteCount"": 821,
        ""voteAverage"": 6.8,
        ""originalLanguage"": ""en"",
        ""genres"": ""Horror, Mystery, Thriller"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/kZNHR1upJKF3eTzdgl5V8s8a4C3.jpg""
      },
      {
        ""releaseDate"": ""2022-02-10T00:00:00"",
        ""title"": ""Kimi"",
        ""overview"": ""A tech worker with agoraphobia discovers recorded evidence of a violent crime but is met with resistance when she tries to report it. Seeking justice, she must do the thing she fears the most: she must leave her apartment."",
        ""popularity"": 1601.782,
        ""voteCount"": 206,
        ""voteAverage"": 6.3,
        ""originalLanguage"": ""en"",
        ""genres"": ""Thriller"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/okNgwtxIWzGsNlR3GsOS0i0Qgbn.jpg""
      },
      {
        ""releaseDate"": ""2022-02-17T00:00:00"",
        ""title"": ""Fistful of Vengeance"",
        ""overview"": ""A revenge mission becomes a fight to save the world from an ancient threat when superpowered assassin Kai tracks a killer to Bangkok."",
        ""popularity"": 1594.013,
        ""voteCount"": 114,
        ""voteAverage"": 5.3,
        ""originalLanguage"": ""en"",
        ""genres"": ""Action, Crime, Fantasy"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/3cccEF9QZgV9bLWyupJO41HSrOV.jpg""
      },
      {
        ""releaseDate"": ""2021-11-03T00:00:00"",
        ""title"": ""Eternals"",
        ""overview"": ""The Eternals are a team of ancient aliens who have been living on Earth in secret for thousands of years. When an unexpected tragedy forces them out of the shadows, they are forced to reunite against mankind’s most ancient enemy, the Deviants."",
        ""popularity"": 1537.406,
        ""voteCount"": 4726,
        ""voteAverage"": 7.2,
        ""originalLanguage"": ""en"",
        ""genres"": ""Science Fiction"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/zByhtBvX99ZiCQhac1sh9d9r6nb.jpg""
      },
      {
        ""releaseDate"": ""2022-02-18T00:00:00"",
        ""title"": ""Pursuit"",
        ""overview"": ""Detective Breslin crosses paths with Calloway, a ruthless hacker desperate to find his wife, who has been kidnapped by a drug cartel. When Calloway escapes police custody, Breslin joins forces with a no-nonsense female cop to reclaim his prisoner. But is Calloway’s crime-boss father somehow involved in this explosive situation?"",
        ""popularity"": 1500.523,
        ""voteCount"": 16,
        ""voteAverage"": 5.9,
        ""originalLanguage"": ""en"",
        ""genres"": ""Action, Crime, Thriller"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/wYihSXWYqN8Ejsdut2P1P0o97N0.jpg""
      },
      {
        ""releaseDate"": ""2021-08-06T00:00:00"",
        ""title"": ""My Hero Academia: World Heroes' Mission"",
        ""overview"": ""A mysterious group called Humarize strongly believes in the Quirk Singularity Doomsday theory which states that when quirks get mixed further in with future generations, that power will bring forth the end of humanity. In order to save everyone, the Pro-Heroes around the world ask UA Academy heroes-in-training to assist them and form a world-classic selected hero team. It is up to the heroes to save the world and the future of heroes in what is the most dangerous crisis to take place yet in My Hero Academia."",
        ""popularity"": 1485.064,
        ""voteCount"": 100,
        ""voteAverage"": 7.3,
        ""originalLanguage"": ""ja"",
        ""genres"": ""Animation, Action, Fantasy, Adventure"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/4NUzcKtYPKkfTwKsLjwNt8nRIXV.jpg""
      },
      {
        ""releaseDate"": ""2022-02-25T00:00:00"",
        ""title"": ""Restless"",
        ""overview"": ""After going to extremes to cover up an accident, a corrupt cop's life spirals out of control when he starts receiving threats from a mysterious witness."",
        ""popularity"": 1468.377,
        ""voteCount"": 107,
        ""voteAverage"": 5.9,
        ""originalLanguage"": ""fr"",
        ""genres"": ""Action, Thriller, Crime"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/aw4GGsRwhQtyLsjzC7dsAahfCDY.jpg""
      },
      {
        ""releaseDate"": ""2021-12-02T00:00:00"",
        ""title"": ""Nightmare Alley"",
        ""overview"": ""An ambitious carnival man with a talent for manipulating people with a few well-chosen words hooks up with a female psychiatrist who is even more dangerous than he is."",
        ""popularity"": 1455.144,
        ""voteCount"": 952,
        ""voteAverage"": 7.1,
        ""originalLanguage"": ""en"",
        ""genres"": ""Crime, Drama, Thriller"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/680klE0dIreQQOyWKFgNnCAJtws.jpg""
      },
      {
        ""releaseDate"": ""2022-01-28T00:00:00"",
        ""title"": ""The Ice Age Adventures of Buck Wild"",
        ""overview"": ""The fearless one-eyed weasel Buck teams up with mischievous possum brothers Crash & Eddie as they head off on a new adventure into Buck's home: The Dinosaur World."",
        ""popularity"": 1431.307,
        ""voteCount"": 737,
        ""voteAverage"": 7.1,
        ""originalLanguage"": ""en"",
        ""genres"": ""Animation, Comedy, Adventure, Family"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/zzXFM4FKDG7l1ufrAkwQYv2xvnh.jpg""
      },
      {
        ""releaseDate"": ""2022-02-25T00:00:00"",
        ""title"": ""Hotel Transylvania: Transformania"",
        ""overview"": ""When Van Helsing's mysterious invention, the \""Monsterfication Ray,\"" goes haywire, Drac and his monster pals are all transformed into humans, and Johnny becomes a monster. In their new mismatched bodies, Drac and Johnny must team up and race across the globe to find a cure before it's too late, and before they drive each other crazy."",
        ""popularity"": 1373.778,
        ""voteCount"": 288,
        ""voteAverage"": 7,
        ""originalLanguage"": ""en"",
        ""genres"": ""Animation, Family, Fantasy, Comedy, Adventure"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/teCy1egGQa0y8ULJvlrDHQKnxBL.jpg""
      },
      {
        ""releaseDate"": ""2022-02-18T00:00:00"",
        ""title"": ""Texas Chainsaw Massacre"",
        ""overview"": ""In this sequel, influencers looking to breathe new life into a Texas ghost town encounter Leatherface, an infamous killer who wears a mask of human skin."",
        ""popularity"": 1312.79,
        ""voteCount"": 521,
        ""voteAverage"": 5.1,
        ""originalLanguage"": ""en"",
        ""genres"": ""Horror"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/meRIRfADEGVo65xgPO6eZvJ0CRG.jpg""
      },
      {
        ""releaseDate"": ""2022-01-28T00:00:00"",
        ""title"": ""The Requin"",
        ""overview"": ""A couple on a romantic getaway find themselves stranded at sea when a tropical storm sweeps away their villa. In order to survive, they are forced to fight the elements, while sharks circle below."",
        ""popularity"": 1252.317,
        ""voteCount"": 65,
        ""voteAverage"": 4.6,
        ""originalLanguage"": ""en"",
        ""genres"": ""Thriller"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/i0z8g2VRZP3dhVvvSMilbOZMKqR.jpg""
      },
      {
        ""releaseDate"": ""2022-02-04T00:00:00"",
        ""title"": ""Looop Lapeta"",
        ""overview"": ""When her boyfriend loses a mobster's cash, Savi races against the clock to save the day — if only she can break out of a curious cycle of dead ends."",
        ""popularity"": 1240.946,
        ""voteCount"": 31,
        ""voteAverage"": 6,
        ""originalLanguage"": ""hi"",
        ""genres"": ""Action, Comedy, Crime"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/onGdT8sYi89drvSJyEJnft97rOq.jpg""
      },
      {
        ""releaseDate"": ""2021-11-04T00:00:00"",
        ""title"": ""Red Notice"",
        ""overview"": ""An Interpol-issued Red Notice is a global alert to hunt and capture the world's most wanted. But when a daring heist brings together the FBI's top profiler and two rival criminals, there's no telling what will happen."",
        ""popularity"": 1178.544,
        ""voteCount"": 3193,
        ""voteAverage"": 6.8,
        ""originalLanguage"": ""en"",
        ""genres"": ""Action, Comedy, Crime, Thriller"",
        ""posterUrl"": ""https://image.tmdb.org/t/p/original/lAXONuqg41NwUMuzMiFvicDET9Y.jpg""
      }
    ]";
}