--(soru1)
SELECT city.city, country.country
FROM city
INNER JOIN country ON city.country_id = country.country_id;
--(soru2)
SELECT customer.first_name, customer.last_name, payment.payment_id
FROM customer
INNER JOIN payment ON customer.customer_id = payment.customer_id;
--(soru3)
SELECT customer.first_name, customer.last_name, rental.rental_id
FROM customer
INNER JOIN rental on customer.customer_id = rental.customer_id;
