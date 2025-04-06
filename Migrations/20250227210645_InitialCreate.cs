using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InClass6s.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    activityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activityLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fireteamSize = table.Column<int>(type: "int", nullable: false),
                    difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isMatchMade = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.activityID);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "activityID", "activityDescription", "activityLocation", "activityName", "activityType", "difficulty", "fireteamSize", "isMatchMade" },
                values: new object[,]
                {
                    { 1, "A timeless Vex raid that challenges Guardians with puzzles and powerful foes.", "Venus", "Vault of Glass", "Raid", "Master", 6, false },
                    { 2, "A raid deep within the Dreaming City to defeat Riven, the final Ahamkara.", "Dreaming City", "Last Wish", "Raid", "Master", 6, false },
                    { 3, "A raid set on Europa, uncovering the secrets of Clovis Bray and the Exo origin.", "Europa", "Deep Stone Crypt", "Raid", "Master", 6, false },
                    { 4, "A raid against Oryx, the Taken King, deep within the Dreadnaught.", "Dreadnaught", "King’s Fall", "Raid", "Master", 6, false },
                    { 5, "A raid against Nezarec aboard the Witness’s Pyramid ship.", "Pyramid Ship", "Root of Nightmares", "Raid", "Master", 6, false },
                    { 6, "A dungeon inside Calus’ mind to uncover secrets of the Leviathan.", "Leviathan", "Duality", "Dungeon", "Master", 3, false },
                    { 7, "A dungeon to prevent a Vex incursion in a Braytech facility.", "Mars", "Spire of the Watcher", "Dungeon", "Master", 3, false },
                    { 8, "A dungeon set beneath the oceans of Titan against the Lucent Hive.", "Titan", "Ghosts of the Deep", "Dungeon", "Master", 3, false },
                    { 9, "A high-stakes version of a Strike with increasing difficulty tiers.", "Varies", "Nightfall: The Ordeal (Normal)", "Strike", "Normal", 3, true },
                    { 10, "A high-stakes version of a Strike with increasing difficulty tiers.", "Varies", "Nightfall: The Ordeal (Legend)", "Strike", "Legend", 3, false },
                    { 11, "A high-stakes version of a Strike with increasing difficulty tiers.", "Varies", "Nightfall: The Ordeal (Master)", "Strike", "Master", 3, false },
                    { 12, "A brutal test of skill with Champions and deadly modifiers.", "Varies", "Nightfall: The Ordeal (Grandmaster)", "Strike", "Grandmaster", 3, false },
                    { 13, "A pinnacle 3v3 PvP activity that rewards flawless victories.", "The Crucible", "Trials of Osiris", "PvP", "High Difficulty", 3, false },
                    { 14, "A week-long PvP event where power level matters.", "The Crucible", "Iron Banner", "PvP", "Normal", 6, true },
                    { 15, "A competitive PvP mode where lives are limited.", "The Crucible", "Survival", "PvP", "Legend", 3, true },
                    { 16, "A hybrid PvPvE mode where two teams compete to defeat enemies and summon a Primeval.", "The Drifter's Arena", "Gambit", "PvPvE", "Normal", 4, true },
                    { 17, "A game show-style activity hosted by Xûr with rotating challenges.", "Eternity", "Dares of Eternity", "PvE", "Legend", 6, true },
                    { 18, "A more difficult version of the campaign offering better rewards.", "Varies", "Legendary Campaign", "PvE", "Legend", 1, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
