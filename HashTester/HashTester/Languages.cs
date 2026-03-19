using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HashTester
{
    public static class Languages
    {
        private static string currentlyUsedLanguage = Settings.SelectedLanguage;
        private static Dictionary<string, string> mainDictionary;
        public static Dictionary<string, string> reverseDictionary;

        /// <summary>
        /// Returns text based on selected language using BFE (Big Fucking Enum)
        /// </summary>
        public static string Translate(L id)
        {
            string key = id.ToString();
            return Translate(key);
        }

        /// <summary>
        /// Returns text based on selected language using string key
        /// </summary>
        public static string Translate(string key)
        {
            if (mainDictionary == null)
            {
                if (!LoadDictionary(currentlyUsedLanguage))
                {
                    return $"Missing translation for {key}";
                }
            }

            if (mainDictionary.TryGetValue(key, out var value))
            {
                return value;
            }
            Console.WriteLine($"!WARNING! Missing translation for: {key}");
            return $"Missing translation: {key}";
        }

        public static string TranslateFromTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return "Missing tag";
            }

            if (Enum.TryParse<L>(tag, out var enumValue))
            {
                return Translate(enumValue);
            }

            Console.WriteLine($"!WARNING! Invalid enum key: {tag}");
            return $"Invalid key: {tag}";
        }

        /// <summary>
        /// Loads the JSON dictionary for a given language
        /// </summary>
        public static bool LoadDictionary(string nameOfLanguage)
        {
            try
            {
                string pathToJson = Path.Combine(Settings.DirectoryToLanguages, nameOfLanguage + ".json");
                if (!File.Exists(pathToJson))
                {
                    Console.WriteLine($"!WARNING! Language file for {nameOfLanguage} is missing.");
                    return false;
                }
                string json = File.ReadAllText(pathToJson, Encoding.UTF8);
                Dictionary<string, string> tempDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                if (tempDictionary == null)
                {
                    Console.WriteLine($"!WARNING! Failed to parse language file for {nameOfLanguage}.");
                    return false;
                }
                mainDictionary = tempDictionary;
                currentlyUsedLanguage = nameOfLanguage;
                BuildReverseDictionary(); //Create Evil Dicionary for reverse translation
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading translation for: " + nameOfLanguage + Environment.NewLine + ex.Message, Languages.Translate(Languages.L.Error) ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Returns array of string containing all the languages (.json) in Languages folder
        /// </summary>
        public static string[] AllLanguages()
        {
            var list = new List<string>();
            foreach (string s in Directory.GetFiles(Settings.DirectoryToLanguages))
            {
                //Console.WriteLine("FIle Extention for Languages: " + Path.GetExtension(s));
                if (Path.GetExtension(s) == ".json") //grab all json files
                {
                    list.Add(Path.GetFileNameWithoutExtension(s));
                }
            }
            return list.ToArray();
        }

        public static void BuildReverseDictionary()
        {
            if (mainDictionary == null)
            {
                Console.WriteLine("!WARNING! Cannot build reverse dictionary because main dictionary is not loaded.");
                return;
            }

            reverseDictionary = mainDictionary
                .GroupBy(kvp => kvp.Value)      // handle duplicates gracefully
                .ToDictionary(g => g.Key, g => g.First().Key);
        }

        public static string GetKeyFromText(string displayedText)
        {
            if (reverseDictionary == null)
            {
                return null;
            }
            reverseDictionary.TryGetValue(displayedText, out var key);
            return key;
        }

        #region Big Fucking Enum

        //**GENERATED L DO NOT EDIT START**//
        public enum L
    {
        Abandoned,
        Aborted,
        AbortTheProcess,
        Algorithm,
        AllHashidDeletedSuccessfully,
        AllOutputstylesAreBool,
        AMajorUpdateIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases,
        AMinorUpdateIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases,
        And,
        AndHash,
        AnErrorHasOccuredInTheProgram,
        AnErrorHasOccuredPleaseContactTheCreatorAndReportThisBug,
        AnErrorHasOccuredWhileTryingToCheckForUpdates,
        ANewVersionOfTheApplicationIsAvailable,
        ANewVersionOfTheApplicationIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases,
        AreYouSureYouWantToResetAllSettings,
        Attempts,
        AttemptsLimit,
        AverageSpeed,
        AverageSpeedS,
        Binary,
        BinSupports01110001WithOrWithoutSpacesBetween,
        BoolMeans0FalseAnd1TrueEverythingOtherTakesSpecialInput,
        BruteForceAttack,
        BruteForceTimeEstimator,
        ButTheUserWants,
        Calculate,
        CalculateAllChecksums,
        Cancel,
        CancelTheProcess,
        ClearListbox,
        Clipboard,
        ClipboardError,
        Collision,
        CollisionDetected,
        CollisionFinder,
        CollisionFound,
        CollisionHash,
        CollisionChecker,
        CommentThisProgramSupportsFormatsStringHexBinAndWorksOnLinesFirstIsFormatThenTwoLinesWillBeReadAndComparedForAnExampleTryToGenerateACollisionInHashingcollisionform,
        CommonHash,
        Confirmation,
        Copy,
        Correct,
        CouldNotConvertInputToString,
        CouldNotFindACollisionUnderTheGivenAttempts,
        CouldNotFindAnyPasswordAssosiatedWithThisHashid,
        CouldNotFindAnySaltpepperAssosiatedWithThisHashid,
        CouldNotFindAPasswordUnderTheGivenAttempts,
        CouldNotFindCollision,
        CouldNotFindPasswordInTheFile,
        CouldNotFindTheOriginalPassword,
        CouldNotFindTheRegistryToDelete,
        CouldNotReadTheContentsOfThisFile,
        CouldNotRunTheDictionaryAttack,
        CountingErrorOccurredWeRecommendChoosingSmallerNumbers,
        CpuDescription,
        CpuInfo,
        CumulativeChanceToFind,
        CurrentlyWorkingOnLine,
        CurrentSpeed,
        CurrentSpeedS,
        CurrentVersion,
        CustomFile,
        DarkTheme,
        DatabaseDeletedSuccessfully,
        Days,
        Default,
        DeleteAllId,
        DictionaryAttack,
        DidntFindAnyNameAssosiatedWithThisId,
        Digits,
        DisplayPasswordAsHex,
        DoNotRemindMeAboutUpdatesAtStartup,
        DoYouReallyWantToDeleteTheAllHashid,
        DoYouReallyWantToDeleteTheEntireDatabase,
        DoYouReallyWantToDeleteThisRegistryFromTheDatabase,
        DoYouReallyWantToOverrideAnotherHashIdYouCouldLoseData,
        DoYouUseSha1YesOrRipemd160No,
        Error,
        ErrorCouldNotStopTheProcess,
        ErrorFetchingCpuDetails,
        FailedToCopyToClipboard,
        fast4you2,
        FileDeleted,
        FileDoesntExists,
        FileHasNotBeenSaved,
        FileChecksum,
        FileChecksumTool,
        FileIsAlreadyARainbowTable,
        FileIsHashedWith,
        FileIsNotARainbowTable,
        FileLocation,
        FileTxt,
        FindingCollisions,
        Found,
        FoundHashViaDictionaryAttack,
        FoundPasswordAtLine,
        FoundPasswordHash,
        FoundPasswordInHex,
        FoundPasswordInUtf8,
        From0To100,
        From1ToMaxNumberOfThreads,
        FullInputPasswordBeforeHashing,
        FullVersion,
        Generate,
        GenerateACollision,
        GenerateARainbowTable,
        GeneratePepper,
        GenerateSalt,
        GoBack,
        GradualHasher,
        GradualHashing,
        HasBeenFoundInWordlistAtLine,
        Hash,
        HashAFile,
        HashCollisionFinder,
        HashCollisionChecker,
        HashedPassword,
        HashedWith,
        Hashid,
        Hashing,
        HashingAlgorithmIsDone,
        Hashtester,
        HashText,
        HasNotBeenFoundInWordlistGoodJob,
        HasPriorityOverSettings,
        Hex,
        HexSupports8db7Or8db7DoesntMatterIfLowercaseOrUppercase,
        HigherRefreshRateCanCausePerformanceIssues,
        Hours,
        HowManyThreadsDoYouWantToUseInAProgram,
        HowManyTimesASecondDoYouWantToUpdateTheUiForSpecificOperations,
        ChanceToFindIn,
        Check,
        CheckACollisionFromATxt,
        CheckCollision,
        Checksum,
        ChecksumCheck,
        ChecksumsAreCorrectFilesAreTheSame,
        ChecksumsAreNotCorrectFilesAreNotTheSame,
        IdOfHash,
        IfYouDontSetHashidSaltNorPepperWillBeSavedDoYouWishToContinue,
        IfYouWantToAddMoreOrSomethingDifferentYouCanJustMakeSureTheFormatIsTheSame,
        IHaveIncludedCommentsOnWhatValueIsAllowedOtherwiseADefaultValueWillBeSet,
        IncludeAllOptions,
        IncludeHashingAlgorithm,
        IncludeNumbering,
        IncludeOriginalText,
        IncludeOwnPepper,
        IncludeOwnSalt,
        IncludeSaltAndPepper,
        Info,
        InfoAboutTheId,
        InHashYouCanFindBothHashesForText1And2ThisIsJustForUserAndCanBeChangedFreelyWhyWouldYouDoThatTho,
        InputCancelled,
        InputFormat,
        InputTextsDoNotCollide,
        Into,
        InvalidFileFormatOrFileNotFoundCancellingDictionaryAttack,
        InvalidValuesPleaseEnterWholeNumbersOnly,
        IRecommendUsingADifferentPassword,
        KnowThatMilisecondsArePreferedByTheComputer,
        KnowThatPercentagesArePreferedByTheComputer,
        Languages,
        Lenght,
        LenghtOfPepper,
        LenghtOfPepperUsedIs,
        LenghtOfSalt,
        LenghtOfTheRandomText,
        LightTheme,
        ListBox,
        LoggedInSuccessfully,
        Login,
        LogSaveAbbandoned,
        LogSavedFrom,
        LogSavedOn,
        LogSaveSuccessfully,
        Lowercase,
        LowerThreadCountCanSlowDownCalculations,
        MainForm,
        Manufacturer,
        MaxClockSpeed,
        MaximumAttempts,
        MaximumNumberOfThreads,
        MeansOnlyOneThreadMayBeUsedAtAllTimes0,
        MessageBox,
        Mhz,
        Minutes,
        Months,
        MultiHasher,
        MultipleHashing,
        Name,
        NewVersion,
        NoPathSelectedCancellingProcess,
        Normal,
        NotUsingSaltAndPepper,
        NumberOfAllPossibleCombinations,
        NumberOfAttempts,
        NumberOfCores,
        NumberOfChars,
        NumberOfLinesProcessed,
        NumberOfLinesToProcess,
        NumberOfPossibleCombinations,
        NumberOfThreads,
        NumberOfThreadsAssigned,
        NumberOfThreadsMaxUsedInPercentage,
        NumberOfThreadsUsed,
        OnLine,
        Options,
        OriginalHash,
        OriginalPassword,
        OriginalPasswordHash,
        OutputStyle,
        OutputType,
        OutputtypeFrom0To2,
        OwnPepper,
        OwnSalt,
        Password,
        PasswordCracker,
        PasswordForm,
        PasswordFound,
        PasswordFoundWithRainbowTableAttack,
        PasswordTester,
        PathChanged,
        PathToWordlist,
        Pepper,
        PepperNotInicialized,
        PercentageOfThreadsUsed,
        PerformanceMode,
        PerformanceModeOff,
        PerformanceModeOn,
        PleaseDontNameAnyFilesInThisDirectoryTempOrInputsplitTheyWillBeDeleted,
        PleaseEnterANonzeroIntegerUpTo1000OrAPasswordInNumberOfCharactersPassword,
        PleaseEnterANonzeroIntegerUpTo2BillionInNumberOfAttemptsS,
        PleaseEnterValidInputIntoText01,
        PleaseEnterValidInputIntoText02,
        PleaseEnterValidValues,
        PleaseChooseAtLeastOneAlgorithm,
        PleaseInputAHashForChecksum,
        PleaseMoveTheProgramToAFolderWhereItHasReadwriteFileAccessOrRunTheApplicationWithAdministrativePrivileges,
        PleaseSelectAHashForChecksum,
        PleaseSelectAnItemFromTheListBeforeCopying,
        PleaseSelectAnItemFromTheLogListboxBeforeCopying,
        PleaseSetNumberFrom1To125,
        PleaseSetNumbersFrom8To1000,
        PleaseSetTextBeforeHashing,
        PleaseSetThePercentageValueFrom0To100,
        PleaseWriteHashidIntoTheTextbox,
        PleaseWriteNameIntoTheNameTextbox,
        PleaseWritePasswordIntoThePasswordTextbox,
        PreferredLanguage,
        ProgramCouldNotGenerateTheRainbowTableAbbandoningProcess,
        ProgramMadeBy,
        ProgressBar,
        Question,
        RainbowTableAttack,
        RainbowTableAttackAbbandoned,
        RainbowTableGeneratorAbandoned,
        RainbowTableHasBeenGeneratedSuccesfully,
        RainbowTableOfTheFile,
        Register,
        Registered,
        RegistryDeletedSuccessfully,
        RemindMeAboutUpdatesAtStartup,
        Remove,
        RemoveAll,
        ResetAllSettings,
        RockyouHasOver14MilPasswordsYouCanDownloadItFromHere,
        Salt,
        SaltAndPepper,
        SaltAndPepperBool,
        SaltAndPepperForm,
        SaltAndPepperChooser,
        SaltAndPepperQuestions,
        SaltAndPepperTester,
        SaltNotInicialized,
        SaltSavedForThisId,
        Save,
        Saved,
        SaveLog,
        Seconds,
        SelectAFile,
        SelectAFolder,
        Settings,
        ShortVersion,
        ShowAlgorithm,
        ShowAllId,
        ShowAllRegisteredUsers,
        ShowInfo,
        ShowLogInListbox,
        SingleThread,
        Specials,
        SpeedS,
        StartingTheProcessInNormalMode,
        StartingTheProcessInPerformanceMode,
        StopTimerSec,
        String,
        StringSupportsUtf8FormatExampleAl85wth,
        SuccesfullyRegistered,
        Success,
        SystemTheme,
        TargetFramesPerSecond,
        Text,
        TheAlgorithmsNeedsToBeTheSameCancellingAttack,
        TheInitialSetupOfTheFoldersFailedPleaseResolveTheIssueBeforeContinuingToUseTheProgram,
        TheProcessHasBeenAbandoned,
        TheProgramCouldNotFindThePasswordWithinTheAttemptLimit,
        TheProgramCouldNotFindThePasswordWithinTheTimeLimit,
        TheProgramFailedToRenameTheFilesWeRecommendToMoveOrDeleteTemporaryFilesBeforeGeneratingTheTableAgain,
        TheProgramWillOnlyCheckTheFirstFormatAndTexts,
        ThereAreNoHashids,
        ThereAreNoIdsToShow,
        ThereAreNoInformationsToShowAboutHashid,
        ThereAreNoRegisteredUsersInDatabase,
        ThereAreUnsavedChangesDoYouWishToSaveThem,
        ThereMustAlwaysBeAnAlgorithmAndItMustBeBeforeTheFormatSupportedFormatsMd5sha1sha256sha512ripemd160crc32ExampleAlgorithmripemd160,
        TheUserHasAbortedTheProcess,
        ThisHashidFileDoesNotExist,
        ThisIdIsAssociatedWithName,
        ThisNameIsAlreadyRegistered,
        ThreadManager,
        Threads2,
        Threads4,
        Threads8,
        ThreadsAndCpuSettings,
        ThreadsForm,
        Timer,
        TimeToFind,
        TimeToUpdateMiliseconds,
        Ui,
        UiManager,
        UiUpdateFrequency,
        UiUpdaterForm,
        Unknown,
        UnknownLenght,
        UpdateuiInMiliseconds,
        Uppercase,
        UsedAlgorithm,
        UsedAlgorithmForLogin,
        UsedPepper,
        UsedSalt,
        UseHexToDisplayText,
        UsePepper,
        Username,
        UsernameNotFoundInDatabase,
        UseSalt,
        VeryShortVersion,
        Visualmode,
        VisualmodeFrom0To2,
        WantToDeleteAnUnfinishedFile,
        Warning,
        WarningIfTheresNothingAfterTheItWillSetTheSettingIntoDefault,
        WarningThereWillBeSeveralOfTheseFiles,
        WholeNumber1100,
        WholeNumber81000,
        WillNotUseSaltpepper,
        WillOverwriteTheIncludeHashingAlgorithmInTheOutputStyleSettings,
        With,
        WouldYouLikeToSaveCollisionToATxtFile,
        WouldYouLikeToSaveFoundPasswordToATxtFile,
        Wrong,
        WrongPassword,
        Years,
        Yes,
    }
        //**GENERATED L DO NOT EDIT END**//

        #endregion //End Big Fucking Enum
    }
}

