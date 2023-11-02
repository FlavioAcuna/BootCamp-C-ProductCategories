CREATE DATABASE IF NOT EXISTS shopDb;
use  shopDb;
-- -----------------------------------------------------
-- Table `mydb`.`Products`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS Products (
  `ProductId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) ,
  `Description` TEXT ,
  `Price` DECIMAL ,
  `CreatedAt` DATETIME  DEFAULT CURRENT_TIMESTAMP(),
  `UpdateAt` DATETIME  DEFAULT CURRENT_TIMESTAMP(),
  PRIMARY KEY (`ProductId`));


-- -----------------------------------------------------
-- Table `mydb`.`Categories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS Categories (
  `CategoryId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) ,
  `CreatedAt` DATETIME  DEFAULT CURRENT_TIMESTAMP(),
  `UpdateAt` DATETIME  DEFAULT CURRENT_TIMESTAMP(),
  PRIMARY KEY (`CategoryId`));


-- -----------------------------------------------------
-- Table `mydb`.`Associations`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS Associations (
  `AssociationId` INT NOT NULL AUTO_INCREMENT,
  `ProductId` INT NOT NULL,
  `CategoryId` INT NOT NULL,
  PRIMARY KEY (AssociationId),
  INDEX `fk_Products_has_Categories_Categories1_idx` (`CategoryId` ASC) VISIBLE,
  INDEX `fk_Products_has_Categories_Products_idx` (`ProductId` ASC) VISIBLE,
  CONSTRAINT `fk_Products_has_Categories_Products`
    FOREIGN KEY (`ProductId`)
    REFERENCES Products (`ProductId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Products_has_Categories_Categories1`
    FOREIGN KEY (`CategoryId`)
    REFERENCES Categories (`CategoryId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
    
-- -----------------------------------------------------
-- INSERT Products
-- -----------------------------------------------------
insert into Products(Name,Description,Price) values("Iphone 15 Pro","¿El iPhone 15 Pro te permite elegir entre varias distancias focales. Es como llevar siete lentes profesionales en el bolsillo.",1.499);
insert into Products(Name,Description,Price) values("Iphone 15 ","¿El iPhone 15 ...",799);
insert into Products(Name,Description,Price) values("Televisor 24' Samsung ","...",500);
insert into Products(Name,Description,Price) values("Televisor 50' Samsung ","...",500);
select * from Products;
-- -----------------------------------------------------
-- INSERT Categories
-- -----------------------------------------------------
insert into Categories(Name) values("Televisores");
insert into Categories(Name) values("Celulares");
select * from Categories;
-- -----------------------------------------------------
-- INSERT Associations
-- -----------------------------------------------------
insert into Associations(ProductId,CategoryId) values(4,2);
insert into Associations(ProductId,CategoryId) values(3,2);
insert into Associations(ProductId,CategoryId) values(1,1);
insert into Associations(ProductId,CategoryId) values(2,1);
insert into Associations(ProductId,CategoryId) values(1,3);
select * from Associations;
