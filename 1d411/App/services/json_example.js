http://localhost:30447/layouts/names
var layoutNames = [
    "Default layout",
    "Hero",
    "Horizontal layout"
]

//http://localhost:30447/layouts/
var layouts = [
    {
        "partials": [
        {
            "textContents": null,
            "position": 1,
            "partialType": "Text",
            "id": 1
        },
        {
            "textContents": null,
            "position": 3,
            "partialType": "Text",
            "id": 2
        },
        {
            "diagramInfo": 666,
            "type": "",
            "position": 2,
            "partialType": "Diagram",
            "id": 3
        }
        ],
        "name": "Hero",
        "templateUrl": "hero",
        "id": 1
    },
    {
        "partials": [
        {
            "textContents": null,
            "position": 1,
            "partialType": "Text",
            "id": 4
        },
        {
            "diagramInfo": 222,
            "type": "",
            "position": 2,
            "partialType": "Diagram",
            "id": 5
        }
        ],
        "name": "Default layout",
        "templateUrl": "default_template",
        "id": 2
    },
    {
        "partials": [
        {
            "diagramInfo": 111,
            "type": "",
            "position": 1,
            "partialType": "Diagram",
            "id": 6
        },
        {
            "diagramInfo": 222,
            "type": "",
            "position": 2,
            "partialType": "Diagram",
            "id": 7
        },
        {
            "diagramInfo": 333,
            "type": "",
            "position": 3,
            "partialType": "Diagram",
            "id": 8
        }
        ],
        "name": "Horizontal layout",
        "templateUrl": "horizontal",
        "id": 3
    }
]

//http://localhost:30447/layouts/1
var layout = {
    "partials": [
    {
        "textContents": [
        {
            "content": "Hero heading",
            "textType": 0,
            "type": "Heading",
            "id": 1
        },
        {
            "content": null,
            "textType": 2,
            "type": "Footer",
            "id": 2
        },
        {
            "content": "A defense officer, Nameless, was summoned by the King of Qin regarding his success of terminating three warriors.",
            "textType": 1,
            "type": "Paragraph",
            "id": 3
        },
        {
            "content": "In ancient China, before the reign of the first emperor, warring factions throughout the Six Kingdoms plot to assassinate the most powerful ruler, Qin. When a minor official defeats Qin's three principal enemies, he is summoned to the palace to tell Qin the story of his surprising victory",
            "textType": 1,
            "type": "Paragraph",
            "id": 4
        }
        ],
        "position": 1,
        "partialType": "Text",
        "id": 1
    },
    {
        "textContents": [
        {
            "content": "Flying Daggers",
            "textType": 0,
            "type": "Heading",
            "id": 5
        },
        {
            "content": null,
            "textType": 2,
            "type": "Footer",
            "id": 6
        },
        {
            "content": "A romantic police captain breaks a beautiful member of a rebel group out of prison to help her rejoin her fellows, but things are not what they seem.",
            "textType": 1,
            "type": "Paragraph",
            "id": 7
        },
        {
            "content": "During the reign of the Tang dynasty in China, a secret organization called 'The House of the Flying Daggers' rises and opposes the government. A police officer called Leo sends officer Jin to investigate a young dancer named Mei, claiming that she has ties to the 'Flying Daggers'. Leo arrests Mei, only to have Jin breaking her free in a plot to gain her trust and lead the police to the new leader of the secret organization. But things are far more complicated than they seem...",
            "textType": 1,
            "type": "Paragraph",
            "id": 8
        },
        {
            "content": "To prepare for her role, Ziyi Zhang lived with a blind girl for two months. The blind girl became blind at the age of 12 because of a brain tumor.",
            "textType": 1,
            "type": "Paragraph",
            "id": 9
        },
        {
            "content": "Towards the end of the 'Echo Game', Leo throws the entire bowl of beans into the drums. They fall the floor, but when Leo moves to Mei, they have all disappeared.",
            "textType": 1,
            "type": "Paragraph",
            "id": 10
        }
        ],
        "position": 3,
        "partialType": "Text",
        "id": 2
    },
    {
        "diagramInfo": 666,
        "type": "",
        "position": 2,
        "partialType": "Diagram",
        "id": 3
    }
    ],
    "name": "Hero",
    "templateUrl": "hero",
    "id": 1
}

http://localhost:30447/screens
var screens = [
{
    "name": "Lager",
    "timer": 0,
    "id": 1
}
]

http://localhost:30447/screens/1
var screen = 
{
    "name": "Lager",
    "timer": 0,
    "id": 1
}


http://localhost:30447/screens/laouts/1

var layoutsWithScreenId = [
{
    "partials": [
    {
        "textContents": null,
        "position": 1,
        "partialType": "Text",
        "id": 1
    },
    {
        "textContents": null,
        "position": 3,
        "partialType": "Text",
        "id": 2
    },
    {
        "diagramInfo": 666,
        "type": "",
        "position": 2,
        "partialType": "Diagram",
        "id": 3
    }
    ],
    "name": "Hero",
    "templateUrl": "hero",
    "id": 1
},
{
    "partials": [
    {
        "textContents": null,
        "position": 1,
        "partialType": "Text",
        "id": 4
    },
    {
        "diagramInfo": 222,
        "type": "",
        "position": 2,
        "partialType": "Diagram",
        "id": 5
    }
    ],
    "name": "Default layout",
    "templateUrl": "default_template",
    "id": 2
}
]