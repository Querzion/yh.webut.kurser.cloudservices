async function handleSubmit(event) {
    event.preventDefault();

    const request = {
        name: event.target["name"].value,
        price: event.target["price"].value
    }

    const res = await fetch("https://localhost:7140/api/products", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(request)
    });

    if (res.ok) {
        const data = await res.json();
        console.log(data);
    }
}