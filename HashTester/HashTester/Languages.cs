using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HashTester
{
    public static class Languages
    {
        private static Dictionary<int, string> dictionary = null; // current language
        private static Dictionary<string, int> englishLookup = null; // English text → ID
        private static Dictionary<int, string> englishDictionary = null; // ID → English text
        private static string currentlyUsedLanguage = "English";


        /// <summary>
        /// Returns text based on selected language. Uses BFE (Big Fucking Enum)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string Translate(L id)
        {
            return Translate((int)id);
        }

        /// <summary>
        /// Returns text based on selected language. Doesnt use BFE (Big Fucking Enum)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string Translate(int id)
        {
            if (dictionary == null && !LoadDictionary("English")) return "error";

            if (dictionary != null && dictionary.TryGetValue(id, out string value) && !string.IsNullOrEmpty(value))
            {
                return value;
            }

            // Fallback to English if available
            if (englishDictionary == null)
            {
                LoadEnglishLookup();
            }
            if (englishDictionary != null && englishDictionary.TryGetValue(id, out string englishValue))
            {
                return englishValue;
            }
            return $"Missing translation for {id}";
        }

        public static string Translate(string englishText)
        {
            if (englishLookup == null)
            {
                LoadEnglishLookup();
            }
            if (englishLookup.TryGetValue(englishText.Trim(), out int id))
            {
                return Translate(id);
            }
            return englishText; // Fallback to original text if no mapping found
        }

        public static string CurrentlyUsedLanguage => currentlyUsedLanguage;

        public enum L
        {
            //**LANGUAGE-CHECKER GENERATED ENUM START
Hashing = 0,
SaltAndPepper = 1,
MultipleHashing = 2,
FindingCollisions = 3,
PasswordCracker = 4,
UseSalt = 5,
UsePepper = 6,
Options = 7,
Settings = 8,
OutputType = 9,
OutputStyle = 10,
Visualmode = 11,
UiUpdateFrequency = 13,
ThreadsAndCpuSettings = 14,
ResetAllSettings = 15,
SystemTheme = 16,
LightTheme = 17,
DarkTheme = 18,
Languages = 23,
FileTxt = 24,
IncludeOriginalText = 25,
IncludeNumbering = 26,
IncludeHashingAlgorithm = 27,
IncludeSaltAndPepper = 28,
IncludeAllOptions = 29,
HashText = 31,
HashAFile = 32,
FileChecksum = 33,
FileLocation = 34,
SelectAFile = 35,
ChecksumCheck = 36,
CalculateAllChecksums = 37,
InputCancelled = 41,
AreYouSureYouWantToResetAllSettings = 45,
Confirmation = 46,
FileDoesntExists = 47,
DoYouUseSha1YesOrRipemd160No = 48,
PleaseInputAHashForChecksum = 49,
ChecksumsAreCorrectFilesAreTheSame = 50,
ChecksumsAreNotCorrectFilesAreNotTheSame = 51,
Correct = 52,
Wrong = 53,
Checksum = 54,
FileHasNotBeenSaved = 55,
AnErrorHasOccuredPleaseContactTheCreatorAndReportThisBug = 56,
PleaseSelectAHashForChecksum = 57,
GradualHashing = 101,
PleaseSelectAnItemFromTheListBeforeCopying = 102,
PleaseSetTextBeforeHashing = 103,
WillNotUseSaltpepper = 104,
CheckCollision = 111,
GenerateACollision = 112,
CheckACollisionFromATxt = 113,
StartingTheProcessInPerformanceMode = 114,
NumberOfThreadsAssigned = 115,
StartingTheProcessInNormalMode = 116,
CollisionFound = 117,
Collision = 118,
CollisionHash = 119,
Attempts = 120,
TimeToFind = 121,
WouldYouLikeToSaveCollisionToATxtFile = 123,
CollisionDetected = 124,
CommonHash = 125,
InputTextsDoNotCollide = 126,
CommentThisProgramSupportsFormatsStringHexBinAndWorksOnLinesFirstIsFormatThenTwoLinesWillBeReadAndComparedForAnExampleTryToGenerateACollisionInHashingcollisionform = 130,
TheProgramWillOnlyCheckTheFirstFormatAndTexts = 131,
StringSupportsUtf8FormatExampleAl85wth = 132,
HexSupports8db7Or8db7DoesntMatterIfLowercaseOrUppercase = 133,
BinSupports01110001WithOrWithoutSpacesBetween = 134,
ThereMustAlwaysBeAnAlgorithmAndItMustBeBeforeTheFormatSupportedFormatsMd5sha1sha256sha512ripemd160crc32ExampleAlgorithmripemd160 = 135,
InHashYouCanFindBothHashesForText1And2ThisIsJustForUserAndCanBeChangedFreelyWhyWouldYouDoThatTho = 136,
InputFormat = 201,
String = 202,
Binary = 204,
Text = 205,
Check = 206,
WillOverwriteTheIncludeHashingAlgorithmInTheOutputStyleSettings = 221,
ShowAlgorithm = 222,
PleaseChooseAtLeastOneAlgorithm = 223,
ProgressBar = 241,
AbortTheProcess = 242,
CurrentSpeedS = 244,
AverageSpeedS = 245,
DictionaryAttack = 247,
BruteForceTimeEstimator = 248,
BruteForceAttack = 250,
FullVersion = 251,
ShortVersion = 252,
VeryShortVersion = 253,
CustomFile = 254,
NumberOfChars = 256,
Password = 257,
SpeedS = 258,
Lowercase = 259,
Uppercase = 260,
Digits = 261,
Specials = 262,
Calculate = 263,
Normal = 264,
Hash = 265,
GenerateARainbowTable = 266,
RainbowTableAttack = 267,
MaximumAttempts = 268,
Lenght = 269,
StopTimerSec = 270,
UnknownLenght = 271,
DisplayPasswordAsHex = 272,
RockyouHasOver14MilPasswordsYouCanDownloadItFromHere = 273,
IfYouWantToAddMoreOrSomethingDifferentYouCanJustMakeSureTheFormatIsTheSame = 274,
Yes = 275,
CurrentlyWorkingOnLine = 276,
PathToWordlist = 277,
NoPathSelectedCancellingProcess = 278,
TheUserHasAbortedTheProcess = 279,
HasBeenFoundInWordlistAtLine = 281,
IRecommendUsingADifferentPassword = 282,
HasNotBeenFoundInWordlistGoodJob = 283,
NumberOfPossibleCombinations = 287,
RainbowTableHasBeenGeneratedSuccesfully = 288,
ProgramCouldNotGenerateTheRainbowTableAbbandoningProcess = 289,
RainbowTableGeneratorAbandoned = 290,
FoundHashViaDictionaryAttack = 291,
OriginalPassword = 292,
OriginalPasswordHash = 293,
FoundPasswordAtLine = 294,
FoundPasswordHash = 295,
FoundPasswordInUtf8 = 296,
FoundPasswordInHex = 297,
TheProgramCouldNotFindThePasswordWithinTheTimeLimit = 298,
TheProgramCouldNotFindThePasswordWithinTheAttemptLimit = 299,
CouldNotFindPasswordInTheFile = 300,
CouldNotRunTheDictionaryAttack = 301,
InvalidFileFormatOrFileNotFoundCancellingDictionaryAttack = 302,
NumberOfLinesProcessed = 303,
NumberOfAllPossibleCombinations = 304,
PerformanceModeOn = 305,
PerformanceModeOff = 306,
PasswordFound = 307,
OriginalHash = 308,
CouldNotFindAPasswordUnderTheGivenAttempts = 312,
CouldNotFindTheOriginalPassword = 313,
WouldYouLikeToSaveFoundPasswordToATxtFile = 314,
ErrorCouldNotStopTheProcess = 315,
PasswordFoundWithRainbowTableAttack = 316,
PleaseDontNameAnyFilesInThisDirectoryTempOrInputsplitTheyWillBeDeleted = 317,
RainbowTableAttackAbbandoned = 318,
DoYouReallyWantToOverrideAnotherHashIdYouCouldLoseData = 401,
Salt = 402,
Pepper = 403,
GenerateSalt = 404,
GeneratePepper = 405,
LenghtOfSalt = 406,
LenghtOfPepper = 407,
IncludeOwnSalt = 408,
IncludeOwnPepper = 409,
OwnSalt = 410,
OwnPepper = 411,
IdOfHash = 412,
Generate = 413,
IfYouDontSetHashidSaltNorPepperWillBeSavedDoYouWishToContinue = 414,
Username = 415,
HowManyThreadsDoYouWantToUseInAProgram = 421,
PercentageOfThreadsUsed = 423,
From1ToMaxNumberOfThreads = 424,
From0To100 = 425,
SingleThread = 426,
Threads2 = 427,
Threads4 = 428,
Threads8 = 429,
MaximumNumberOfThreads = 430,
MeansOnlyOneThreadMayBeUsedAtAllTimes0 = 431,
KnowThatPercentagesArePreferedByTheComputer = 432,
LowerThreadCountCanSlowDownCalculations = 433,
Save = 434,
Default = 435,
Cancel = 436,
CpuInfo = 437,
Name = 438,
Manufacturer = 439,
NumberOfCores = 440,
NumberOfThreads = 441,
MaxClockSpeed = 442,
CpuDescription = 443,
Unknown = 444,
Mhz = 445,
ErrorFetchingCpuDetails = 446,
PleaseSetThePercentageValueFrom0To100 = 447,
HowManyTimesASecondDoYouWantToUpdateTheUiForSpecificOperations = 501,
TargetFramesPerSecond = 502,
TimeToUpdateMiliseconds = 503,
PleaseSetNumberFrom1To125 = 504,
PleaseSetNumbersFrom8To1000 = 505,
KnowThatMilisecondsArePreferedByTheComputer = 506,
HigherRefreshRateCanCausePerformanceIssues = 507,
PleaseEnterValidValues = 508,
InvalidValuesPleaseEnterWholeNumbersOnly = 509,
LogSavedOn = 551,
LogSavedFrom = 552,
LogSaveSuccessfully = 553,
LogSaveAbbandoned = 554,
SelectAFolder = 556,
PathChanged = 557,
SaltNotInicialized = 571,
PepperNotInicialized = 572,
Found = 573,
OnLine = 574,
Years = 575,
Months = 576,
Days = 577,
Hours = 578,
Minutes = 579,
Seconds = 580,
RainbowTableOfTheFile = 581,
With = 582,
HashingAlgorithmIsDone = 583,
FileIsAlreadyARainbowTable = 584,
FileIsNotARainbowTable = 585,
FileIsHashedWith = 586,
ButTheUserWants = 587,
TheAlgorithmsNeedsToBeTheSameCancellingAttack = 588,
WarningIfTheresNothingAfterTheItWillSetTheSettingIntoDefault = 589,
BoolMeans0FalseAnd1TrueEverythingOtherTakesSpecialInput = 590,
IHaveIncludedCommentsOnWhatValueIsAllowedOtherwiseADefaultValueWillBeSet = 591,
VisualmodeFrom0To2 = 592,
UpdateuiInMiliseconds = 593,
WholeNumber81000 = 594,
NumberOfThreadsMaxUsedInPercentage = 595,
WholeNumber1100 = 596,
PreferredLanguage = 597,
OutputtypeFrom0To2 = 598,
AllOutputstylesAreBool = 599,
SaltAndPepperBool = 600,
NumberOfLinesToProcess = 601,
ThereAreUnsavedChangesDoYouWishToSaveThem = 602,
AttemptsLimit = 603,
Hashid = 612,
ThereAreNoIdsToShow = 613,
PleaseWriteNameIntoTheNameTextbox = 614,
PleaseWritePasswordIntoThePasswordTextbox = 615,
PleaseWriteHashidIntoTheTextbox = 616,
LoggedInSuccessfully = 617,
WrongPassword = 618,
ThereAreNoInformationsToShowAboutHashid = 619,
ThereAreNoRegisteredUsersInDatabase = 620,
DoYouReallyWantToDeleteTheEntireDatabase = 621,
DatabaseDeletedSuccessfully = 622,
ThisNameIsAlreadyRegistered = 623,
NotUsingSaltAndPepper = 624,
HashedPassword = 625,
SuccesfullyRegistered = 626,
UsedAlgorithmForLogin = 627,
UsernameNotFoundInDatabase = 628,
UsedSalt = 629,
UsedPepper = 630,
FullInputPasswordBeforeHashing = 631,
ThisIdIsAssociatedWithName = 632,
AndHash = 633,
HashedWith = 634,
DidntFindAnyNameAssosiatedWithThisId = 635,
CouldNotFindAnyPasswordAssosiatedWithThisHashid = 636,
SaltSavedForThisId = 637,
LenghtOfPepperUsedIs = 638,
CouldNotFindAnySaltpepperAssosiatedWithThisHashid = 639,
DoYouReallyWantToDeleteTheAllHashid = 640,
ThereAreNoHashids = 641,
AllHashidDeletedSuccessfully = 642,
DoYouReallyWantToDeleteThisRegistryFromTheDatabase = 643,
RegistryDeletedSuccessfully = 644,
CouldNotFindTheRegistryToDelete = 645,
HasPriorityOverSettings = 646,
ShowInfo = 648,
Login = 649,
Remove = 650,
RemoveAll = 651,
ShowAllRegisteredUsers = 652,
InfoAboutTheId = 653,
ShowAllId = 654,
DeleteAllId = 655,
ThisHashidFileDoesNotExist = 656,
Hashtester = 701,
FileChecksumTool = 702,
GradualHasher = 703,
CollisionFinder = 704,
CollisionChecker = 705,
MultiHasher = 706,
PasswordTester = 707,
SaltAndPepperChooser = 708,
SaltAndPepperTester = 709,
ThreadManager = 710,
UiManager = 711,
CumulativeChanceToFind = 712,
ChanceToFindIn = 713,
MessageBox = 714,
ListBox = 715,
ClearListbox = 10000,
SaveLog = 10001,
Clipboard = 10002,
FailedToCopyToClipboard = 10003,
ClipboardError = 10004,
CancelTheProcess = 10005,
GoBack = 10006,
LenghtOfTheRandomText = 10008,
Timer = 10009,
NumberOfAttempts = 10010,
CurrentSpeed = 10011,
AverageSpeed = 10012,
ShowLogInListbox = 10013,
UseHexToDisplayText = 10014,
PerformanceMode = 10015,
CouldNotFindACollisionUnderTheGivenAttempts = 10016,
TheProcessHasBeenAbandoned = 10017,
CouldNotFindCollision = 10018,
Abandoned = 10019,
Error = 10020,
And = 10021,
CouldNotReadTheContentsOfThisFile = 10022,
PleaseSelectAnItemFromTheLogListboxBeforeCopying = 10023,
Algorithm = 10024,
Warning = 10025,
NumberOfThreadsUsed = 10026,
Into = 10027,
Saved = 10028,
Copy = 10029,
Question = 10030,
Info = 10031,
Aborted = 10032,
Success = 10033,
Registered = 10034,
Register = 10035,
Ui = 10036,
Hex = 10037,
ProgramMadeBy = 10039,
fast4you2 = 10040,
ANewVersionOfTheApplicationIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases = 10041,
AMajorUpdateIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases = 10042,
AMinorUpdateIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases = 10043,
DoNotRemindMeAboutUpdatesAtStartup = 10044,
ANewVersionOfTheApplicationIsAvailable = 10045,
NewVersion = 10046,
CurrentVersion = 10047,
AnErrorHasOccuredWhileTryingToCheckForUpdates = 10048,
RemindMeAboutUpdatesAtStartup = 10049,
AnErrorHasOccuredInTheProgram = 11000,
PleaseEnterANonzeroIntegerUpTo2BillionInNumberOfAttemptsS = 11001,
PleaseEnterANonzeroIntegerUpTo1000OrAPasswordInNumberOfCharactersPassword = 11002,
WantToDeleteAnUnfinishedFile = 11003,
FileDeleted = 11004,
WarningThereWillBeSeveralOfTheseFiles = 11005,
CountingErrorOccurredWeRecommendChoosingSmallerNumbers = 11006,
TheProgramFailedToRenameTheFilesWeRecommendToMoveOrDeleteTemporaryFilesBeforeGeneratingTheTableAgain = 11007,
PleaseMoveTheProgramToAFolderWhereItHasReadwriteFileAccessOrRunTheApplicationWithAdministrativePrivileges = 11008,
TheInitialSetupOfTheFoldersFailedPleaseResolveTheIssueBeforeContinuingToUseTheProgram = 11009,
PleaseEnterValidInputIntoText01 = 11010,
PleaseEnterValidInputIntoText02 = 11011,
CouldNotConvertInputToString = 11012,
UsedAlgorithm = 11013,
MainForm = 15000,
HashCollisionFinder = 15002,
HashCollisionChecker = 15003,
PasswordForm = 15005,
ThreadsForm = 15006,
UiUpdaterForm = 15007,
SaltAndPepperForm = 15008,
SaltAndPepperQuestions = 15009,
//**LANGUAGE-CHECKER GENERATED ENUM END
        }


        /// <summary>
        /// Loads dictionary from the folder Languages
        /// </summary>
        /// <param name="nameOfLanguage"></param>
        /// <returns></returns>
        public static bool LoadDictionary(string nameOfLanguage)
        {
            try
            {
                string pathToFile = GetPath(nameOfLanguage);
                if (string.IsNullOrEmpty(pathToFile) || !File.Exists(pathToFile))
                {
                    MessageBox.Show("Missing Translation for: " + nameOfLanguage + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Do not use Translation, could cause stackoverflow
                    return false;
                }

                dictionary = new Dictionary<int, string>();
                currentlyUsedLanguage = nameOfLanguage;

                foreach (var line in File.ReadLines(pathToFile))
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("//") && line.Contains("=="))
                    {
                        string[] split = line.Split(new[] { "==" }, StringSplitOptions.None);
                        if (split.Length == 2 && int.TryParse(split[0], out int id)) dictionary[id] = split[1];
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Missing Translation for: " + nameOfLanguage + "." + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Do not use Translation, could cause stackoverflow
                return false;
            }
        }


        /// <summary>
        /// Load English
        /// </summary>
        private static void LoadEnglishLookup()
        {
            englishLookup = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            englishDictionary = new Dictionary<int, string>();

            string englishPath = GetPath("English");
            if (!string.IsNullOrEmpty(englishPath) && File.Exists(englishPath))
            {
                foreach (var line in File.ReadLines(englishPath))
                {
                    if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("//") && line.Contains("=="))
                    {
                        string[] split = line.Split(new[] { "==" }, StringSplitOptions.None);
                        if (split.Length == 2 && int.TryParse(split[0], out int id))
                        {
                            string text = split[1].Trim();
                            if (!englishLookup.ContainsKey(text)) englishLookup[text] = id;
                            if (!englishDictionary.ContainsKey(id)) englishDictionary[id] = text;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Returns array of string containing all the languages in Languages folder
        /// </summary>
        /// <returns></returns>
        public static string[] AllLanguages()
        {
            var list = new List<string>();
            foreach (string s in Directory.GetFiles(Settings.DirectoryToLanguages))
            {
                if (!Path.GetFileName(s).StartsWith("_"))
                    list.Add(Path.GetFileNameWithoutExtension(s));
            }
            return list.ToArray();
        }


        /// <summary>
        /// Returns a path of a specific language
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetPath(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            string languagesPath = Settings.DirectoryToLanguages;
            if (!Directory.Exists(languagesPath)) return null;

            foreach (string file in Directory.GetFiles(languagesPath, "*.txt"))
                if (string.Equals(
                                            Path.GetFileNameWithoutExtension(file),
                                            name,
                                            StringComparison.OrdinalIgnoreCase))
                    return file;

            return null;
        }
    }
}
