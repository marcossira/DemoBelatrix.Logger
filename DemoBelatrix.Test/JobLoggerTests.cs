using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoBelatrix.Logger;
using System.Collections.Generic;

namespace DemoBelatrix.Test
{
    [TestClass]
    public class JobLoggerTests
    {
        JobLogger logger;
        ConfigurationLog config;
        [TestInitialize]
        public void Setup()
        {            
            config = new ConfigurationLog();
        }
        [TestMethod]
        public void ConfigurateToLogErrorsOnConsole()
        {
            config.logError = true;
            config.logToConsole = true;
            logger = new JobLogger(config);

            Assert.AreEqual(true, logger.configurationLog.logError);
        }
        [TestMethod]
        public void ConfigurateToLogMessageOnConsole()
        {
            config.logMessage = true;
            config.logToConsole = true;
            logger = new JobLogger(config);

            Assert.AreEqual(true, logger.configurationLog.logMessage);
        }

        [TestMethod]
        public void ConfigurateToLogWarningsOnConsole()
        {
            config.logWarning = true;
            config.logToConsole = true;
            logger = new JobLogger(config);

            Assert.AreEqual(true, logger.configurationLog.logWarning);
        }        

        [TestMethod]
        public void ConsoleRedOnError()
        {
            config.logError = true;
            config.logToConsole = true;
            logger = new JobLogger(config);
            string msg = string.Empty;

            logger.LogMessage(msg, MessageLogType.Error);
            Assert.AreEqual(ConsoleColor.Red, Console.ForegroundColor);
        }

        [TestMethod]
        public void ConsoleYellowOnWarning()
        {
            config.logWarning = true;
            config.logToConsole = true;
            logger = new JobLogger(config);
            string msg = string.Empty;

            logger.LogMessage(msg, MessageLogType.Warning);
            Assert.AreEqual(ConsoleColor.Yellow, Console.ForegroundColor);
        }

        [TestMethod]
        public void ConsoleWhiteOnMessage()
        {
            config.logMessage = true;
            config.logToConsole = true;
            logger = new JobLogger(config);
            string msg = string.Empty;

            logger.LogMessage(msg, MessageLogType.Message);
            Assert.AreEqual(ConsoleColor.White, Console.ForegroundColor);
        }

    }
}
