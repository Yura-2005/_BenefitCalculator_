pipeline {
    agent any

    tools {
        dotnet 'dotnet'  // Використання .NET SDK
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/Yura-2005/_BenefitCalculator_.git'  // Вкажи свій репозиторій
            }
        }

        stage('Build') {
            steps {
                script {
                    bat 'dotnet restore'
                    bat 'dotnet build --configuration Release'
                }
            }
        }

        stage('Run Tests') {  
            steps {
                script {
                    bat 'if exist TestResults rd /s /q TestResults'  
                    bat 'dotnet test BenefitCalculator.Tests\\BenefitCalculator.Tests.csproj --logger "trx;LogFileName=test-results.trx" --results-directory TestResults'
                }
            }
        }

        stage('Convert TRX to JUnit') {
            steps {
                bat 'dotnet tool install --global trx2junit || exit 0' // Встановлюємо trx2junit, якщо його немає
                bat 'trx2junit TestResults/test-results.trx' // Конвертуємо у JUnit-формат
            }
        }

        stage('Publish Test Results') {
            steps {
                publishXUnit(
                    tools: [XUnitDotNetTestType(pattern: 'TestResults/test-results.junit.xml')]
                )
            }
        }

        stage('Publish') {
            steps {
                script {
                    bat 'dotnet publish BenefitCalculator\\BenefitCalculator.csproj -c Release -r win-x64 --self-contained true -o D:\\Code_.NET\\BenefitCalculator\\BenefitCalculator\\publish'
                }
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: 'TestResults/*.trx', fingerprint: true
            junit 'TestResults/test-results.junit.xml'
        }
    }
}
