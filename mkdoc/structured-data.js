document.addEventListener("DOMContentLoaded", function() {
    const jsonLdScript = document.createElement("script");
    jsonLdScript.type = "application/ld+json";
    jsonLdScript.innerHTML = JSON.stringify({
        "@context": "https://schema.org",
        "@type": "WebPage",
        "name": document.title,
        "url": window.location.href
    });
    document.head.appendChild(jsonLdScript);
});
