window.setCulture = function (culture, returnUrl) {
    const form = document.createElement("form");
    form.method = "post";
    form.action = "/set-culture";

    const c = document.createElement("input");
    c.type = "hidden";
    c.name = "culture";
    c.value = culture;

    const r = document.createElement("input");
    r.type = "hidden";
    r.name = "returnUrl";
    r.value = returnUrl;

    form.appendChild(c);
    form.appendChild(r);
    document.body.appendChild(form);
    form.submit();
};
