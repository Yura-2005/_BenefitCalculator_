pipeline {
    agent any

    tools {
        dotnet 'dotnet'
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/Yura-2005/_BenefitCalculator_.git' 
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
            publishXUnit([
                tools: [XUnitDotNetTestType(pattern: '**/TestResults/*.trx')]
            ])
            archiveArtifacts artifacts: '**/TestResults/*.trx', fingerprint: true
        }
    }
}