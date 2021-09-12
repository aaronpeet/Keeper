CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS keeps(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'keep Name',
  description varchar(255) COMMENT 'keep description',
  img varchar(255) COMMENT 'User Picture',
  views INT NOT NULL COMMENT 'keep views count',
  shares INT NOT NULL COMMENT 'keep shared count',
  keeps INT NOT NULL COMMENT 'kept count',
  creatorId VARCHAR(255) NOT NULL COMMENT 'account id for creator',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'keep Name',
  description varchar(255) COMMENT 'keep description',
  isPrivate TINYINT COMMENT 'is this vault private',
  creatorId VARCHAR(255) NOT NULL COMMENT 'account id for creator',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
