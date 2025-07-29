export const fetchData = async (url: string) => {
    const response = await fetch(url);
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }
    return response.json();
};

export const translate = (key: string, language: string) => {
    const translations = {
        en: {
            greeting: "Hello",
            farewell: "Goodbye"
        },
        pt: {
            greeting: "Olá",
            farewell: "Adeus"
        },
        es: {
            greeting: "Hola",
            farewell: "Adiós"
        }
    };
    return translations[language][key] || key;
};