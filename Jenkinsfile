pipeline {
    agent any

    environment {
        DOTNET_PROJECT_PATH = 'BenefitCalculator/BenefitCalculator.csproj' // Правильний шлях до .csproj
        PUBLISH_DIR = 'D:\\Code_.NET\\BenefitCalculator\\BenefitCalculator\\publish'
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/Yura-2005/_BenefitCalculator_.git'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                bat """
                    dotnet publish ${DOTNET_PROJECT_PATH} -c Release -r win-x64 --self-contained true -o ${PUBLISH_DIR}
                """
            }
        }
    }
}