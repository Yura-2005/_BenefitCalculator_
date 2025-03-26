pipeline {
    agent any

    tools {
        dotnet 'dotnet'  // Вказує, що Jenkins використовує .NET SDK
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/Yura-2005/_BenefitCalculator_.git'  // Вказуй свій репозиторій
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
                    bat 'dotnet test BenefitCalculator.Tests\\BenefitCalculator.Tests.csproj --logger "trx;LogFileName=test-results.trx" --results-directory "TestResults"'
                }
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
            junit 'TestResults/*.trx'
        }
    }
}
