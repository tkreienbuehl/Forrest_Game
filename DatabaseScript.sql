-- MySQL Script generated by MySQL Workbench
-- Thu Aug 17 14:32:35 2017
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema forestGameDb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `forestGameDb` ;

-- -----------------------------------------------------
-- Schema forestGameDb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `forestGameDb` DEFAULT CHARACTER SET utf8 ;
USE `forestGameDb` ;

-- -----------------------------------------------------
-- Table `forestGameDb`.`FACTION`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `forestGameDb`.`FACTION` ;

CREATE TABLE IF NOT EXISTS `forestGameDb`.`FACTION` (
  `FACTION_ID` INT NOT NULL AUTO_INCREMENT,
  `DESCRIPTION` VARCHAR(45) NOT NULL,
  `PICTURE_FILE` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`FACTION_ID`),
  UNIQUE INDEX `DESCRIPTION_UNIQUE` (`DESCRIPTION` ASC),
  UNIQUE INDEX `PICTURE_FILE_UNIQUE` (`PICTURE_FILE` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `forestGameDb`.`DECISION`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `forestGameDb`.`DECISION` ;

CREATE TABLE IF NOT EXISTS `forestGameDb`.`DECISION` (
  `DECISION_ID` INT NOT NULL AUTO_INCREMENT,
  `TEXT` VARCHAR(265) NOT NULL,
  `fk_FACTION_ID` INT NOT NULL,
  PRIMARY KEY (`DECISION_ID`),
  UNIQUE INDEX `TEXT_UNIQUE` (`TEXT` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `forestGameDb`.`INFLUENCE_TYPE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `forestGameDb`.`INFLUENCE_TYPE` ;

CREATE TABLE IF NOT EXISTS `forestGameDb`.`INFLUENCE_TYPE` (
  `INFLUENCE_TYPE_ID` INT NOT NULL AUTO_INCREMENT,
  `NAME` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`INFLUENCE_TYPE_ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `forestGameDb`.`INFLUENCE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `forestGameDb`.`INFLUENCE` ;

CREATE TABLE IF NOT EXISTS `forestGameDb`.`INFLUENCE` (
  `INFLUENCE_ID` INT NOT NULL,
  `VALUE` INT NOT NULL,
  `fk_INFLUENCE_TYPE` INT NOT NULL,
  PRIMARY KEY (`INFLUENCE_ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `forestGameDb`.`ANSWER`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `forestGameDb`.`ANSWER` ;

CREATE TABLE IF NOT EXISTS `forestGameDb`.`ANSWER` (
  `ANSWER_ID` INT NOT NULL,
  `ANSWER` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`ANSWER_ID`),
  UNIQUE INDEX `ANSWER_UNIQUE` (`ANSWER` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `forestGameDb`.`CONNECTED_INFLUENCE`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `forestGameDb`.`CONNECTED_INFLUENCE` ;

CREATE TABLE IF NOT EXISTS `forestGameDb`.`CONNECTED_INFLUENCE` (
  `fk_DECISION_ID` INT NOT NULL,
  `fk_ANSWER_ID` INT NOT NULL,
  `fk_INFLUENCE_ID` INT NOT NULL,
  PRIMARY KEY (`fk_DECISION_ID`, `fk_ANSWER_ID`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;