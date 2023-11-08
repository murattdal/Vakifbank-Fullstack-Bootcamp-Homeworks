--(soru1)
SELECT * FROM film WHERE title LIKE '%n' ORDER BY length DESC LIMIT 5;
--(soru2)
SELECT * FROM film WHERE title LIKE '%n' ORDER BY length ASC OFFSET 5 LIMIT 5;
--(soru3)
SELECT * FROM customer WHERE store_id = 1 ORDER BY last_name DESC LIMIT 4;