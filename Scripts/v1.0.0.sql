CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `lojista` (
    `id_lojista` int(11) NOT NULL AUTO_INCREMENT,
    `razaosocial` varchar(100) NOT NULL,
    `login` varchar(10) NOT NULL,
    `senha` varchar(10) NOT NULL,
    CONSTRAINT `PK_lojista` PRIMARY KEY (`id_lojista`)
);

CREATE TABLE `configuracao` (
    `id_configuracao` int(11) NOT NULL AUTO_INCREMENT,
    `id_lojista` int(11) NOT NULL,
    `stone` char(1) NOT NULL,
    `cielo` char(1) NOT NULL,
    `antifraude` char(1) NOT NULL,
    `rule_visa` char(1) NULL,
    `rule_master` char(1) NULL,
    `stonekey` varchar(45) NULL,
    `cielokey` varchar(45) NULL,
    CONSTRAINT `PK_configuracao` PRIMARY KEY (`id_configuracao`),
    CONSTRAINT `FK_LOJISTA` FOREIGN KEY (`id_lojista`) REFERENCES `lojista` (`id_lojista`) ON DELETE NO ACTION
);

CREATE TABLE `transacao` (
    `id_transacao` int(11) NOT NULL AUTO_INCREMENT,
    `id_lojista` int(11) NOT NULL,
    `descricao` varchar(2000) NOT NULL,
    `valor` decimal(15,2) NOT NULL,
    `cielo` char(1) NULL,
    `stone` char(1) NULL,
    `visa` char(1) NULL,
    `master` char(1) NULL,
    `credit_card` varchar(45) NOT NULL,
    CONSTRAINT `PK_transacao` PRIMARY KEY (`id_transacao`),
    CONSTRAINT `fk_id_loja` FOREIGN KEY (`id_lojista`) REFERENCES `lojista` (`id_lojista`) ON DELETE NO ACTION
);

CREATE INDEX `FK_LOJISTA_idx` ON `configuracao` (`id_lojista`);

CREATE INDEX `fk_id_loja_idx` ON `transacao` (`id_lojista`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180806044503_v.1.0', '2.1.1-rtm-30846');

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180806045600_v.1.0.0', '2.1.1-rtm-30846');

