using Microsoft.EntityFrameworkCore;

namespace InClass6s.Models
{
    public class SmithContext : DbContext
    {
        public DbSet<Activitys> Activities { get; set; }
        public SmithContext(DbContextOptions<SmithContext> options) : base(options) { }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activitys>().HasData(
    // Raids
    new Activitys
    {
        activityID = 1,
        activityName = "Vault of Glass",
        activityDescription = "A timeless Vex raid that challenges Guardians with puzzles and powerful foes.",
        activityLocation = "Venus",
        activityType = "Raid",
        fireteamSize = 6,
        difficulty = "Master",
        isMatchMade = false
    },
    new Activitys
    {
        activityID = 2,
        activityName = "Last Wish",
        activityDescription = "A raid deep within the Dreaming City to defeat Riven, the final Ahamkara.",
        activityLocation = "Dreaming City",
        activityType = "Raid",
        fireteamSize = 6,
        difficulty = "Master",
        isMatchMade = false
    },
    new Activitys
    {
        activityID = 3,
        activityName = "Deep Stone Crypt",
        activityDescription = "A raid set on Europa, uncovering the secrets of Clovis Bray and the Exo origin.",
        activityLocation = "Europa",
        activityType = "Raid",
        fireteamSize = 6,
        difficulty = "Master",
        isMatchMade = false
    },
    new Activitys
    {
        activityID = 4,
        activityName = "King’s Fall",
        activityDescription = "A raid against Oryx, the Taken King, deep within the Dreadnaught.",
        activityLocation = "Dreadnaught",
        activityType = "Raid",
        fireteamSize = 6,
        difficulty = "Master",
        isMatchMade = false
    },
    new Activitys
    {
        activityID = 5,
        activityName = "Root of Nightmares",
        activityDescription = "A raid against Nezarec aboard the Witness’s Pyramid ship.",
        activityLocation = "Pyramid Ship",
        activityType = "Raid",
        fireteamSize = 6,
        difficulty = "Master",
        isMatchMade = false
    },

    // Dungeons
    new Activitys
    {
        activityID = 6,
        activityName = "Duality",
        activityDescription = "A dungeon inside Calus’ mind to uncover secrets of the Leviathan.",
        activityLocation = "Leviathan",
        activityType = "Dungeon",
        fireteamSize = 3,
        difficulty = "Master",
        isMatchMade = false
    },
    new Activitys
    {
        activityID = 7,
        activityName = "Spire of the Watcher",
        activityDescription = "A dungeon to prevent a Vex incursion in a Braytech facility.",
        activityLocation = "Mars",
        activityType = "Dungeon",
        fireteamSize = 3,
        difficulty = "Master",
        isMatchMade = false
    },
    new Activitys
    {
        activityID = 8,
        activityName = "Ghosts of the Deep",
        activityDescription = "A dungeon set beneath the oceans of Titan against the Lucent Hive.",
        activityLocation = "Titan",
        activityType = "Dungeon",
        fireteamSize = 3,
        difficulty = "Master",
        isMatchMade = false
    },

    // Nightfalls
    new Activitys
    {
        activityID = 9,
        activityName = "Nightfall: The Ordeal (Normal)",
        activityDescription = "A high-stakes version of a Strike with increasing difficulty tiers.",
        activityLocation = "Varies",
        activityType = "Strike",
        fireteamSize = 3,
        difficulty = "Normal",
        isMatchMade = true
    },
    new Activitys
    {
        activityID = 10,
        activityName = "Nightfall: The Ordeal (Legend)",
        activityDescription = "A high-stakes version of a Strike with increasing difficulty tiers.",
        activityLocation = "Varies",
        activityType = "Strike",
        fireteamSize = 3,
        difficulty = "Legend",
        isMatchMade = false
    },
    new Activitys
    {
        activityID = 11,
        activityName = "Nightfall: The Ordeal (Master)",
        activityDescription = "A high-stakes version of a Strike with increasing difficulty tiers.",
        activityLocation = "Varies",
        activityType = "Strike",
        fireteamSize = 3,
        difficulty = "Master",
        isMatchMade = false
    },
    new Activitys
    {
        activityID = 12,
        activityName = "Nightfall: The Ordeal (Grandmaster)",
        activityDescription = "A brutal test of skill with Champions and deadly modifiers.",
        activityLocation = "Varies",
        activityType = "Strike",
        fireteamSize = 3,
        difficulty = "Grandmaster",
        isMatchMade = false
    },

    // Crucible (PvP)
    new Activitys
    {
        activityID = 13,
        activityName = "Trials of Osiris",
        activityDescription = "A pinnacle 3v3 PvP activity that rewards flawless victories.",
        activityLocation = "The Crucible",
        activityType = "PvP",
        fireteamSize = 3,
        difficulty = "High Difficulty",
        isMatchMade = false
    },
    new Activitys
    {
        activityID = 14,
        activityName = "Iron Banner",
        activityDescription = "A week-long PvP event where power level matters.",
        activityLocation = "The Crucible",
        activityType = "PvP",
        fireteamSize = 6,
        difficulty = "Normal",
        isMatchMade = true
    },
    new Activitys
    {
        activityID = 15,
        activityName = "Survival",
        activityDescription = "A competitive PvP mode where lives are limited.",
        activityLocation = "The Crucible",
        activityType = "PvP",
        fireteamSize = 3,
        difficulty = "Legend",
        isMatchMade = true
    },

    // Gambit (PvPvE)
    new Activitys
    {
        activityID = 16,
        activityName = "Gambit",
        activityDescription = "A hybrid PvPvE mode where two teams compete to defeat enemies and summon a Primeval.",
        activityLocation = "The Drifter's Arena",
        activityType = "PvPvE",
        fireteamSize = 4,
        difficulty = "Normal",
        isMatchMade = true
    },

    // Seasonal Activities
    new Activitys
    {
        activityID = 17,
        activityName = "Dares of Eternity",
        activityDescription = "A game show-style activity hosted by Xûr with rotating challenges.",
        activityLocation = "Eternity",
        activityType = "PvE",
        fireteamSize = 6,
        difficulty = "Legend",
        isMatchMade = true
    },
    new Activitys
    {
        activityID = 18,
        activityName = "Legendary Campaign",
        activityDescription = "A more difficult version of the campaign offering better rewards.",
        activityLocation = "Varies",
        activityType = "PvE",
        fireteamSize = 1,
        difficulty = "Legend",
        isMatchMade = false
    }
            );
        }
    }
}
