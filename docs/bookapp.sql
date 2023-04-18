CREATE TABLE USERS (
  id INT PRIMARY KEY,
  username VARCHAR(30) NOT NULL,
  first_name VARCHAR(30) NOT NULL,
  last_name VARCHAR(30) NOT NULL,
  email_address VARCHAR(40) NOT NULL,
  profile_picture VARCHAR(100) NULL    ?? 				
);

CREATE TABLE BOOKS (
  id INT PRIMARY KEY,
  author VARCHAR(30) NOT NULL,
  title VARCHAR(30) NOT NULL,
  edition VARCHAR(10) NOT NULL,
  description VARCHAR(500) NOT NULL,
  isbn CHAR(13) NOT NULL,
  course_id INT NOT NULL,
  seller_id INT NOT NULL,
  condition VARCHAR(30) NOT NULL,
  FOREIGN KEY (course_id) REFERENCES COURSES(id),
  FOREIGN KEY (seller_id) REFERENCES USERS(id)
);

CREATE TABLE TRANSACTIONS (
  id INT PRIMARY KEY,
  book_id INT NOT NULL,
  buyer_id INT,
  interested_patrons VARCHAR(500) NOT NULL,
  winning_patron_id INT NOT NULL,
  transaction_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  transaction_amount DECIMAL(10, 2) NOT NULL,
  FOREIGN KEY (book_id) REFERENCES BOOKS(id),
  FOREIGN KEY (buyer_id) REFERENCES USERS(id),
  FOREIGN KEY (winning_patron_id) REFERENCES USERS(id)
);

CREATE TABLE COURSES (
  id INT PRIMARY KEY,
  name VARCHAR(30) NOT NULL
);
