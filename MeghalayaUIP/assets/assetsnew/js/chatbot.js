var modulesCache = null;
var questionsCache = {};
var answersCache = {};
var isModulesLoading = false;

document.addEventListener('DOMContentLoaded', function () {
    try {
        var saved = localStorage.getItem('chatModules_v1');
        if (saved) modulesCache = JSON.parse(saved);
    } catch (e) { console.warn('localStorage read failed', e); }

    prefetchModules();
});

function prefetchModules() {
    if (modulesCache || isModulesLoading) return;
    isModulesLoading = true;
    PageMethods.GetModules(function (mods) {
        isModulesLoading = false;
        modulesCache = mods || [];
        try { localStorage.setItem('chatModules_v1', JSON.stringify(modulesCache)); } catch (e) { }
    }, function (err) {
        isModulesLoading = false;
        console.error('GetModules failed (prefetch)', err);
    });
}

function toggleChat() {
    var w = document.getElementById('chatWindow');

    var isOpening = (w.style.display !== 'block');

    if (isOpening) {
        w.style.display = 'block';
        w.setAttribute('aria-hidden', 'false');

        // Record the click asynchronously
        PageMethods.RecordChatbotClick(function () {
            console.log('Chatbot click recorded');
        }, function (err) {
            console.warn('Click record failed', err);
        });

        // Load modules
        if (modulesCache && modulesCache.length) {
            renderModules(modulesCache);
            return false;
        }
        showLoading('Loading...');
        PageMethods.GetModules(function (modules) {
            hideLoading();
            modulesCache = modules || [];
            renderModules(modulesCache);
        });
    } else {
        w.style.display = 'none';
        w.setAttribute('aria-hidden', 'true');
    }
    return false;

    if (w.style.display === 'block') {
        w.style.display = 'none';
        w.setAttribute('aria-hidden', 'true');
        return false;
    }
    w.style.display = 'block';
    w.setAttribute('aria-hidden', 'false');

    if (modulesCache && modulesCache.length) {
        renderModules(modulesCache);
        return false;
    }

    showLoading('Loading...');
    PageMethods.GetModules(function (modules) {
        hideLoading();
        modulesCache = modules || [];
        try { localStorage.setItem('chatModules_v1', JSON.stringify(modulesCache)); } catch (e) { }
        renderModules(modulesCache);
    }, function (err) {
        hideLoading();
        document.getElementById('chatContent').innerHTML = '<div style="color:crimson">Error loading modules. Try again later.</div>';
        console.error(err);
    });
    return false;
}

function renderModules(mods) {
    var container = document.getElementById('chatContent');
    container.innerHTML = '';
    if (!mods || !mods.length) {
        container.innerHTML = '<div>No modules found.</div>';
        return;
    }
    mods.forEach(function (m) {
        var btn = document.createElement('button');
        btn.textContent = m;
        btn.className = 'module-btn';
        btn.onclick = function () { loadQuestions(m); };
        container.appendChild(btn);
    });
}

function loadQuestions(moduleName) {
    var container = document.getElementById('chatContent');
    if (questionsCache[moduleName]) {
        renderQuestions(moduleName, questionsCache[moduleName]);
        return;
    }
    showLoading('Loading questions...');
    PageMethods.GetQuestions(moduleName, function (questions) {
        hideLoading();
        questionsCache[moduleName] = questions || [];
        renderQuestions(moduleName, questionsCache[moduleName]);
    }, function (err) {
        hideLoading();
        container.innerHTML = '<div style="color:crimson">Error loading questions.</div>';
        console.error(err);
    });
}

function renderQuestions(moduleName, questions) {
    var container = document.getElementById('chatContent');
    container.innerHTML = '';

    var back = document.createElement('button');
    back.textContent = '← Back to modules';
    back.className = 'small-btn';
    back.onclick = function () { renderModules(modulesCache || []); };
    container.appendChild(back);

    questions.forEach(function (q) {
        var btn = document.createElement('button');
        btn.textContent = q.QUESTION;
        btn.onclick = function () { loadAnswer(q.SLNO); };
        container.appendChild(btn);
    });

    if (!questions.length) {
        var p = document.createElement('div');
        p.textContent = 'No questions available in this module.';
        container.appendChild(p);
    }
}

function loadAnswer(slno) {
    var container = document.getElementById('chatContent');
    if (answersCache[slno]) {
        container.innerHTML = formatAnswerHtml(answersCache[slno]);
        return;
    }
    showLoading('Loading answer...');
    PageMethods.GetAnswer(slno, function (answer) {
        hideLoading();
        answersCache[slno] = answer || 'No answer found.';
        container.innerHTML = formatAnswerHtml(answersCache[slno]);
    }, function (err) {
        hideLoading();
        container.innerHTML = '<div style="color:crimson">Error loading answer.</div>';
        console.error(err);
    });
}

//function formatAnswerHtml(answerText) {
//    return '<div>' + (answerText || '') + '</div><br/><button class="small-btn" onclick="toggleChat()">Back</button>';
//}

function formatAnswerHtml(answerText) {
    return `
        <div>${answerText || ''}</div>
        <br/>
        <button class="small-btn" onclick="goBackToQuestions()">← Back</button>
    `;
}
function goBackToQuestions() {
    if (lastModuleName) {
        // Load questions for the same module again
        loadQuestions(lastModuleName);
    } else {
        // Fallback: go back to module list
        renderModules(modulesCache || []);
    }
}
function loadQuestions(moduleName) {
    showLoading('Loading questions...');
    PageMethods.GetQuestions(moduleName, function (questions) {
        hideLoading();
        renderQuestions(moduleName, questions);
    }, function (err) {
        hideLoading();
        document.getElementById('chatContent').innerHTML =
            '<div style="color:crimson">Error loading questions.</div>';
        console.error(err);
    });
}


function showLoading(text) {
    var container = document.getElementById('chatContent');
    container.innerHTML = '<div class="spinner">' + (text || 'Loading...') + '</div>';
}
function hideLoading() { /* no-op: caller replaces content */ }

function closeChat() {
    document.getElementById('chatWindow').style.display = 'none';
}
function incrementChatbotCount() {
    PageMethods.IncrementChatbotClickCount(
        function (newCount) {
            document.getElementById("lblClickCount").textContent = "Chatbot Views: " + newCount;
        },
        function (err) {
            console.error("Error updating click count", err);
        }
    );
}



